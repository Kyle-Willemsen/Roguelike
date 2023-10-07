using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //References
    [HideInInspector] public CharacterController controller;
    PlayerStats pStats;
    public PlayerStatsSO pStatsSO;
    GunSystem gunSystem;
    private Camera cam;

    [Header("Player Stats")]
    //public float baseSpeed;
    public float currentSpeed;
    public bool canMove;


    [Header("Dash Stats")]
    public float dashSpeed;
    public float dashTime;
    public bool canDash = true;
    public GameObject bomb;
    public Image dashImage;


    [Header("Invisibility")]
    public bool isInvisible;
    public float invisibilityCounter;
    public GameObject mesh;

    [Header("Teleport")]
    private GameObject teleportPos;
    public float teleportTimer;
    public bool canNowTeleport;


    [Header("Gravity")]
    public LayerMask layermask;
    public float groundDistance = 0.4f;
    public bool isGrounded;
    public Transform groundCheck;
    private Vector3 velocity;
    public float gravity;

    //Random
    [HideInInspector] public Vector3 facingDir;
    private Vector3 pointToLook;
    public Vector3 move;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        controller = GetComponent<CharacterController>();
        gunSystem = GetComponent<GunSystem>();
        cam = Camera.main;
        dashImage = GameObject.Find("dashCD").GetComponent<Image>();
        dashImage.fillAmount = 0;
        currentSpeed = pStatsSO.BaseMoveSpeed;
        teleportPos = GameObject.Find("TeleportPos");
        canMove = true;
        canNowTeleport = false;
    }

    private void Update()
    {
        Movement();
        MouseLook();
        Gravity();
        if (!canDash)
        {
            dashImage.fillAmount -= 1 / pStatsSO.DashCooldwon * Time.deltaTime;
            if (dashImage.fillAmount <= 0)
            {
                dashImage.fillAmount = 0;
                canDash = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine("DashCoroutine");
            audioManager.Play("PlayerDash");
            CameraShake.Instance.ShakeCamera(1.75f, 0.15f);
            if (pStatsSO.DashBomb)
            {
                Instantiate(bomb, transform.position, Quaternion.identity);
            }
            if (pStatsSO.InvisibleAbility)
            {
                isInvisible = true;
                StartCoroutine(Invisibility());
            }
            if (pStatsSO.TeleportDash)
            {
                StartCoroutine(TeleportBack());
                teleportPos.transform.position = transform.position;
                canNowTeleport = true;
            }
        }

        if (canNowTeleport && Input.GetKeyDown(KeyCode.Q))
        {
            canNowTeleport = false;
            controller.enabled = false;
            transform.position = new Vector3(teleportPos.transform.position.x, teleportPos.transform.position.y, teleportPos.transform.position.z);
            controller.enabled = true;
        }
    }

    private void Movement()
    {
        if (canMove)
        {
            facingDir = new Vector3(pointToLook.x, transform.position.y, pointToLook.z);

            move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            controller.Move(move * Time.deltaTime * currentSpeed);

            if (move != Vector3.zero)
            {
                transform.LookAt(facingDir);
            }
        }

    }

    private void MouseLook()
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(mousePos, out rayLength))
        {
            pointToLook = mousePos.GetPoint(rayLength);

            transform.LookAt(facingDir);
            gunSystem.shootPos.transform.LookAt(facingDir);
        }
    }

    private void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, layermask);
   
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
   
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            //pStats.invincible = true;
            canDash = false;
            dashImage.fillAmount = 1;
            controller.Move(move * dashSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(pStatsSO.DashCooldwon);
        canDash = true;
        //pStats.invincible = false;
    }

    private IEnumerator Invisibility()
    {

        mesh.SetActive(false);
        yield return new WaitForSeconds(invisibilityCounter);
        mesh.SetActive(true);
        isInvisible = false;
        canNowTeleport = true;
    }

    private IEnumerator TeleportBack()
    {
        yield return new WaitForSeconds(teleportTimer);
        canNowTeleport = false;
        
    }
}

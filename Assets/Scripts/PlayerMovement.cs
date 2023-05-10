using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //References
    private CharacterController controller;
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


    [Header("Invisibility")]
    public bool isInvisible;
    public float invisibilityCounter;
    public GameObject mesh;

    [Header("Teleport")]
    private GameObject teleportPos;
    public float teleportTimer;
    public bool canNowTeleport;


    //[Header("Gravity")]
    //public LayerMask layermask;
    //public float groundDistance = 0.4f;
    //public bool isGrounded;
    //public Transform groundCheck;
    //private Vector3 velocity;
    //public float gravity;

    //Random
    [HideInInspector] public Vector3 facingDir;
    private Vector3 pointToLook;
    private Vector3 move;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        gunSystem = GetComponent<GunSystem>();
        cam = Camera.main;

        currentSpeed = pStatsSO.BaseMoveSpeed;
        teleportPos = GameObject.Find("TeleportPos");
        canMove = true;
        canNowTeleport = false;
    }

    private void Update()
    {
        Movement();
        MouseLook();
        // Gravity();


        if (Input.GetKey(KeyCode.Space) && canDash)
        {
            StartCoroutine("DashCoroutine");
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

            move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
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

   // private void Gravity()
   // {
   //     isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, layermask);
   //
   //     if (isGrounded && velocity.y < 0)
   //     {
   //         velocity.y = -2f;
   //     }
   //
   //     velocity.y += gravity * Time.deltaTime;
   //     controller.Move(velocity * Time.deltaTime);
   // }
    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            canDash = false;
            controller.Move(move * dashSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(pStatsSO.DashCooldwon);
        canDash = true;
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

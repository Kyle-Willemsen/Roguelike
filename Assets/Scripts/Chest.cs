using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] List<GameObject> lootChance = new List<GameObject>();

    GameManager manager;
    public float amountOfLootToSpawn;
    public Transform spawnLocation;
    Animator anim;
    private bool canOpen;
    private int randomItem;

    public float radius;
    public LayerMask layerMask;
    [SerializeField] ParticleSystem particles;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        canOpen = true; 
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager.openChestHUD.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager.openChestHUD.SetActive(false);
        }
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layerMask);
        foreach (Collider collider in colliders)
        {
 
            if (Input.GetKeyDown(KeyCode.F) && canOpen)
            {
                manager.openChestHUD.SetActive(false);
                OpenChest();
                canOpen = false;
                particles.Stop();
            }

        }
    }
    
    private void OpenChest()
    {

        CameraShake.Instance.ShakeCamera(0.6f, 0.2f);
        anim.SetBool("isOpen", true);
        randomItem = Random.Range(0, lootChance.Count);

        for (int i = 0; i <= amountOfLootToSpawn; i++)
        { 
            Instantiate(lootChance[randomItem], spawnLocation.position + new Vector3(Random.Range(0, 3), 1, 3), Quaternion.identity);
        }
    }
}

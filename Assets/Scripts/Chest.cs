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


    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        canOpen = true; 
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (canOpen)
        {
            if (other.gameObject.tag == "Player")
            {
                manager.openChestHUD.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    OpenChest();
                    manager.openChestHUD.SetActive(false);
                    canOpen = false;
                }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        manager.openChestHUD.SetActive(false);
    }

    private void Update()
    {

    }

    private void OpenChest()
    {
        anim.SetBool("isOpen", true);
        randomItem = Random.Range(0, lootChance.Count);

        for (int i = 0; i <= amountOfLootToSpawn; i++)
        {
            
            Instantiate(lootChance[randomItem], spawnLocation.position + new Vector3(Random.Range(0, 3), 1, 3), Quaternion.identity);
        }
    }
}

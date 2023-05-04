using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] List<GameObject> lootChance = new List<GameObject>();
    GameObject uiDisplay;
    public float amountOfLootToSpawn;
    public Transform spawnLocation;
    Animator anim;
    private bool canOpen;
    private int randomItem;


    private void Start()
    {
        uiDisplay = GameObject.Find("OpenChest");
        uiDisplay.SetActive(false);
        canOpen = true; 
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (canOpen)
        {
            if (other.gameObject.tag == "Player")
            {
                uiDisplay.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    OpenChest();
                    uiDisplay.SetActive(false);
                    canOpen = false;
                }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        uiDisplay.SetActive(false);
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

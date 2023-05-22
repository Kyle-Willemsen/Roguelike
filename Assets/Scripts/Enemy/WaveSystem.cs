using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] List<GameObject> waveOne = new List<GameObject>();
    [SerializeField] List<GameObject> waveTwo = new List<GameObject>();
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();

    GameManager manager;
    [SerializeField] int amountOfEnemiesToSpawn;
    [SerializeField] float waveCount;
    [SerializeField] GameObject triggerUI;
    private bool canStartWave;



    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        manager.waveInProgress = true;
        canStartWave = true;
    }
    private void Update()
    {
       if (manager.numberOfEnemiesLeft <= 0 && waveCount > 0 && waveCount <= 2)
       {
           SpawnWave();
       }

        if (waveCount == 3 && manager.numberOfEnemiesLeft == 0)
        {
            manager.waveInProgress = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && canStartWave)
        {
            triggerUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                SpawnWave();
                canStartWave = false;
                triggerUI.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        triggerUI.SetActive(false);
    }

    private void SpawnWave()
    {
        waveCount++;

        for (int i = 0; i <= amountOfEnemiesToSpawn; i++)
        {
            Instantiate(waveOne[Random.Range(0, waveOne.Capacity)], spawnPoints[Random.Range(0, 5)].position, Quaternion.identity);
        }
    }
}

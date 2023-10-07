using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalWave : MonoBehaviour
{
    GameManager manager;
    
    public List<Transform> enemySpawnPoints = new List<Transform>();
    public List<Transform> destroyedSpawnPoints = new List<Transform>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public int sceneWaveCounter;

    //public GameObject door;
    public bool waveTriggered;
    public GameObject spawnIcon;
    public bool canSpawn;
    public float numberOfEnemiesToSpawn;


    public bool waveStarted;
    public bool canActivate = true;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
       

        //sceneWaveCounter = 2;
    }

    private void Update()
    {
        if (sceneWaveCounter == 0)
        {
            Invoke("SpawnDoor", 1.5f);
        }

        if (manager.numberOfEnemiesLeft == 0 && sceneWaveCounter > 0 && waveStarted)
        {
            if (canSpawn)
            {
                SpawnWave();
            }
        }
    }

    public void SpawnDoor()
    {
        if (manager.numberOfEnemiesLeft == 0)
        {
            manager.wavesCompleted = true;
        }
    }

    public void SpawnWave()
    {
        if (!waveTriggered)
        {
            sceneWaveCounter--;
            for (int i = 0; i < numberOfEnemiesToSpawn; i++)
            {
                waveTriggered = true;

                Spawn();
                Invoke("ResetTrigger", 2f);

            }
        }
    }

    private void Spawn()
    {
        canSpawn = false;
        int randomSpawn = Random.Range(0, enemySpawnPoints.Count);
        Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Count)], enemySpawnPoints[randomSpawn].position, Quaternion.identity);
        destroyedSpawnPoints.Add(enemySpawnPoints[randomSpawn]);
        enemySpawnPoints.RemoveAt(randomSpawn);
    }

    private void ResetTrigger()
    {
        canSpawn = true;
        waveTriggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && canActivate)
        {
            canActivate = false;
            waveStarted = true;
            SpawnWave();
        }

    }
}

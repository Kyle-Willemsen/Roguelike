using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTEST : MonoBehaviour
{
    GameManager manager;
    StartWaveTEST waveTrigger;
    public List<Transform> enemySpawnPoints = new List<Transform>();
    public List<Transform> destroyedSpawnPoints = new List<Transform>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public int sceneWaveCounter;

    public GameObject door;
    public bool waveTriggered;
    public GameObject spawnIcon;
    public bool canSpawn;



    public bool waveStarted;
    public bool canActivate = true;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        waveTrigger = GameObject.Find("Trigger").GetComponent<StartWaveTEST>();

        sceneWaveCounter = 2;
    }

    private void Update()
    {
        if (sceneWaveCounter == 0 && manager.numberOfEnemiesLeft == 0 && canSpawn)
        {
            door.SetActive(true);
        }

        if (manager.numberOfEnemiesLeft == 0 && sceneWaveCounter > 0 && waveStarted)
        {
            if (canSpawn)
            {
                SpawnWave();
            }
        }
    }

    public void SpawnWave()
    {
        if (!waveTriggered)
        {
            sceneWaveCounter--;
            for (int i = 0; i < 5; i++)
            {
                waveTriggered = true; 
                
                StartCoroutine("Spawn");
                Invoke("ResetTrigger", 2f);

            }
        }
    }

    private IEnumerator Spawn()
    {
        int randomSpawn = Random.Range(0, enemySpawnPoints.Count);
        Instantiate(spawnIcon, enemySpawnPoints[randomSpawn].position, Quaternion.identity);
        //RemoveFromList
        yield return new WaitForSeconds(1.4f);
        //AddBackToList
        Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Count)], enemySpawnPoints[randomSpawn].position, Quaternion.identity);
        canSpawn = false;
    }

    private void ResetTrigger()
    {
        waveTriggered = false;
        canSpawn = true;
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

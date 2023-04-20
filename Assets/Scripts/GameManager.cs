using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Transform> Spawners = new List<Transform>();
    public List<GameObject> Enemies = new List<GameObject>();
    public int randomSpawner;
    public int randomEnemy;

    public float numberOfEnemiesLeft;
    public float spawnedEnemies;
    private GameObject door;

    //public float numberofRoomsEntered;
    public int randomScene;
    [SerializeField]
    TESTSO testSO;


    private void Start()
    {
        door = GameObject.Find("Door");
        door.SetActive(false);

        //randomEnemy = Random.Range(0, Enemies.Count);
    }

    private void Update()
    {
        //if (spawnedEnemies > 0)
        //{
        //    randomSpawner = Random.Range(0, Spawners.Count);
        //    Instantiate(Enemies[randomEnemy], Spawners[randomSpawner].transform.position, Quaternion.identity);
        //    spawnedEnemies--;
        //}

        if (numberOfEnemiesLeft <= 0)
        {
            door.SetActive(true);
        }

        if (testSO.RoomsEntered <= 6)
        {
            randomScene = Random.Range(1, 6);
        }
        if (testSO.RoomsEntered >= 7 && testSO.RoomsEntered <= 12)
        {
            randomScene = Random.Range(7, 11);
        }
    }
}

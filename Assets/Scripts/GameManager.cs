using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public List<Transform> Spawners = new List<Transform>();
    public List<GameObject> Enemies = new List<GameObject>();
    [SerializeField] TextMeshProUGUI soulsHUD;
    [SerializeField] TextMeshProUGUI fragmentSHUD;
    [SerializeField] TextMeshProUGUI potionHUD;
    [SerializeField] PlayerStatsSO pStatsSO;
    private GameObject door;
    public SingleValuesSO soulsCount;
    public SingleValuesSO fragmentsCount;

    [SerializeField] SingleValuesSO roomsEntered;
    public int randomSpawner;
    public int randomEnemy;
    public float numberOfEnemiesLeft;
    public float spawnedEnemies;
    public int randomScene;
    private int potionCounter;
    public bool waveInProgress;


    public List<GameObject> rooms = new List<GameObject>();
    public List<Transform> roomSpawnPoints = new List<Transform>();
    public float amountOfRooms;
    public GameObject shopSelectionRoom;
    private void Start()
    {
        Debug.Log("Start");
        door = GameObject.Find("DoorTest");
        door.SetActive(false);
    }

    private void Update()
    {
        potionCounter = pStatsSO.PotionCounter;
        //if (spawnedEnemies > 0)
        //{
        //    randomSpawner = Random.Range(0, Spawners.Count);
        //    Instantiate(Enemies[randomEnemy], Spawners[randomSpawner].transform.position, Quaternion.identity);
        //    spawnedEnemies--;
        //}

        soulsHUD.text = "Souls:" + soulsCount.Value;
        fragmentSHUD.text = "Fragments:" + fragmentsCount.Value;
        potionHUD.text = "" + potionCounter;

        if (numberOfEnemiesLeft <= 0 && !waveInProgress)
        {
            door.SetActive(true);
        }
       // if (roomsEntered.Value <= 1)
       // {
       //     randomScene = Random.Range(0, 3);
       // }
       //
       // if (roomsEntered.Value > 3 && roomsEntered.Value <= 7)
       // {
       //     randomScene = Random.Range(4, 7);
       // }
       // if (roomsEntered.Value > 7 && roomsEntered.Value <= 11)
       // {
       //     randomScene = Random.Range(8, 12);
       // }

       ///Wave 1
       //f (roomsEntered.Value == 0 || roomsEntered.Value == 4 && roomsEntered.Value < 6)
       //
       //   randomScene = Random.Range(0, 3);
       //
       //f (roomsEntered.Value == 9 || roomsEntered.Value == 13 && roomsEntered.Value < 15)
       //
       //   randomScene = Random.Range(4, 7);
       //
       //f (roomsEntered.Value == 18 || roomsEntered.Value == 22 && roomsEntered.Value < 24)
       //
       //   randomScene = Random.Range(8, 11);
       //

        if (roomsEntered.Value < 2)
        {
            randomScene = Random.Range(0, 4);
            Instantiate(rooms[Random.Range(0, rooms.Count)], roomSpawnPoints[Random.Range(0, roomSpawnPoints.Count)].position, Quaternion.identity);
            Instantiate(rooms[Random.Range(0, rooms.Count)], roomSpawnPoints[Random.Range(0, roomSpawnPoints.Count)].position, Quaternion.identity);
        }

        if (roomsEntered.Value == 3)
        {
            Instantiate(shopSelectionRoom, roomSpawnPoints[1].position, Quaternion.identity);
        }
    }


}

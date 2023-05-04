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
    bool doorsActive = false;


    private void Update()
    {
        potionCounter = pStatsSO.PotionCounter;

        soulsHUD.text = "Souls:" + soulsCount.Value;
        fragmentSHUD.text = "Fragments:" + fragmentsCount.Value;
        potionHUD.text = "" + potionCounter;

        if (numberOfEnemiesLeft <= 0 && !waveInProgress && !doorsActive)
        {
            doorsActive = true;
            InstantiateRooms();

        }
    }

    private void InstantiateRooms()
    {
        if (roomsEntered.Value <= 2)
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

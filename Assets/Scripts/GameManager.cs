using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//using UnityEngine.UIElements;
using UnityEngine.UI;

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
    [SerializeField] TextMeshProUGUI enemiesLeftHUD;
    public GameObject openChestHUD;

    public GameObject pauseScreen;
    public GameObject deathScreen;
    PlayerMovement pMovement;

    public GameObject shopRoom;
    private void Start()
    {
        pMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }

        potionCounter = pStatsSO.PotionCounter;

        soulsHUD.text = "" + soulsCount.Value;
        fragmentSHUD.text = "" + fragmentsCount.Value;
        potionHUD.text = "" + potionCounter;
        enemiesLeftHUD.text = "Enemies Left: " + numberOfEnemiesLeft;

        if (numberOfEnemiesLeft <= 0 && !waveInProgress && !doorsActive)
        {
            doorsActive = true;
            InstantiateRooms();

        }
    }

    private void InstantiateRooms()
    {
        if (roomsEntered.Value <= 3)
        {

            randomScene = Random.Range(0, 4);
            Instantiate(rooms[Random.Range(0, rooms.Count)], roomSpawnPoints[Random.Range(0, roomSpawnPoints.Count)].position, Quaternion.identity);
            Instantiate(rooms[Random.Range(0, rooms.Count)], roomSpawnPoints[Random.Range(0, roomSpawnPoints.Count)].position, Quaternion.identity);
        }

        if (roomsEntered.Value == 4)
        {
            Instantiate(shopRoom, roomSpawnPoints[1].position, Quaternion.identity);
        }
    }

    private void Pause()
    {
        pauseScreen.SetActive(true);
        pMovement.canMove = false;

        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
        pMovement.canMove = true;
    }

    public void Restart()
    {

    }

    public void Options()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void DeathScreen()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
    }

}

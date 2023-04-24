using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<Transform> Spawners = new List<Transform>();
    public List<GameObject> Enemies = new List<GameObject>();
    [SerializeField] TextMeshProUGUI currencyHUD;
    [SerializeField] TextMeshProUGUI hpHUD;
    [SerializeField] PlayerStatsSO pStatsSO;
    private GameObject door;
    public SingleValuesSO totalCurrency;
    
    [SerializeField] SingleValuesSO roomsEntered;
    public int randomSpawner;
    public int randomEnemy;
    public float numberOfEnemiesLeft;
    public float spawnedEnemies;
    public int randomScene;
    private int potionCounter;
    public bool waveInProgress;



    private void Start()
    {
       
        door = GameObject.Find("Door");
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

        currencyHUD.text = "Currency:" + totalCurrency.Value;
        hpHUD.text = "" + potionCounter;

        if (numberOfEnemiesLeft <= 0 && !waveInProgress)
        {
            door.SetActive(true);
        }

        if (roomsEntered.Value <= 6)
        {
            randomScene = Random.Range(1, 6);
        }
        if (roomsEntered.Value >= 7 && roomsEntered.Value <= 12)
        {
            randomScene = Random.Range(7, 11);
        }
    }


}

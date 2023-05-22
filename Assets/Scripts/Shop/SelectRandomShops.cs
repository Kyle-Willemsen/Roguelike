using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRandomShops : MonoBehaviour
{
    public List <GameObject> shops = new List<GameObject>();
    public List <Transform> spawnPoints = new List<Transform>();
    private int randomShop;
    private int randomSpawn;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            randomShop = Random.Range(0, shops.Count);
          //randomSpawn = Random.Range(0, spawnPoints.Count);

            Instantiate(shops[randomShop], spawnPoints[randomSpawn].position, Quaternion.identity);
            shops.RemoveAt(randomShop);
            spawnPoints.RemoveAt(randomSpawn);
        }
    }
    private void Update()
    {
        
    }

}

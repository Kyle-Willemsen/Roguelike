using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTest : MonoBehaviour
{
    public List <GameObject> scenery = new List<GameObject>();
    public List <Transform> spawnPoints = new List<Transform>();
    public int randomProp;
    public int randomPoint;


    private void Start()
    {
        randomProp = Random.Range(0, scenery.Count);
        randomPoint = Random.Range(0, spawnPoints.Count);

        for (int i = 0; i < spawnPoints.Count; i++)
        {

            Instantiate(scenery[randomProp], spawnPoints[randomPoint].position, Quaternion.identity);
        }
    }
    private void Update()
    {
        
    }

}

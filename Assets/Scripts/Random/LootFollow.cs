using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootFollow : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    public Transform target;
    
    public float minSpeed;
    public float maxSpeed;
    
    bool isFollowing;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("LootTarget").transform;
        isFollowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, Time.deltaTime * Random.Range(minSpeed, maxSpeed));
        }
    }

    public void Follow()
    {
        isFollowing = true;
    }
}

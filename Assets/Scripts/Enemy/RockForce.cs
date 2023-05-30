using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockForce : MonoBehaviour
{
    RockSlam rockSlam;
    public GameObject vfxExplosion;


    void Start()
    {
        rockSlam = GetComponentInParent<RockSlam>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(vfxExplosion, rockSlam.transform.position, Quaternion.identity);
        rockSlam.RockExplode();
        Destroy(gameObject);
    }
}

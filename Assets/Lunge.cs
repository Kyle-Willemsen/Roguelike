using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunge : MonoBehaviour
{
    public Rigidbody rb;


    private void Update()
    {

    }
    public void LungeAttack()
    {
        rb.AddForce(0, 20, 10);
    }
}

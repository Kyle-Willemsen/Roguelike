using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSlam : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject rock;
    public float force;
    public float radius;
    public LayerMask layerMask;
    public float damage;

    private bool canGetPounded;

    // Start is called before the first frame update
    void Start()
    {
        canGetPounded = true;
        rb = rock.GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0, -force, 0));

    }

    public void RockExplode()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, radius, layerMask);
        foreach (Collider c in collider)
        {
            if (c.GetComponent<PlayerStats>())
            {
                if (canGetPounded)
                {
                    c.GetComponent<PlayerStats>().TakeDamage(damage);
                    canGetPounded = false;
                }
                //Destroy(gameObject);
            }
            
            Destroy(gameObject, 1f);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    RockExplode();
    //    Destroy(gameObject);
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(rock.transform.position, radius);
    }
}

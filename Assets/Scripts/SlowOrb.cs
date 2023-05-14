using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowOrb : MonoBehaviour
{
    public float radius;
    public float damage;
    public LayerMask layermask;
    bool canDamage;
    public float resetTimer;
    public float lifeSpan;
    //Rigidbody rb;

    private void Start()
    {
        canDamage = true;
        //rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeSpan);
    }
    private void Update()
    {
        //rb.velocity = transform.forward * speed;
        //transform.position += transform.forward * speed * Time.deltaTime;

        Collider[] collider = Physics.OverlapSphere(transform.position, radius, layermask);
        foreach (Collider c in collider)
        {
            if (c.GetComponent<EnemyStats>() && canDamage)
            {
                canDamage = false;
                CameraShake.Instance.ShakeCamera(0.5f, 0.2f);
                Invoke("ResetTick", resetTimer);
                c.GetComponent<EnemyStats>().TakeDamage(damage);
            }
        }
    }

    private void ResetTick()
    {
        canDamage = true;
    }

}

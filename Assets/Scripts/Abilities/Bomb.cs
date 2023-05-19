using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float bombDelay;
    public float blastRadius;
    public LayerMask layerMask;
    public float damage;
    public GameObject vfxBomb;

    private void Start()
    {
        StartCoroutine(BombCounter());
    }
    private IEnumerator BombCounter()
    {
        yield return new WaitForSeconds(bombDelay);
        Instantiate(vfxBomb, transform.position, Quaternion.identity);
        CameraShake.Instance.ShakeCamera(1.5f, 0.5f);
        Explode();
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius, layerMask);
        foreach (Collider c in colliders)
        {
            if (c.GetComponent<EnemyStats>())
            {
                c.GetComponent<EnemyStats>().TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(transform.position, blastRadius);
    // }
}

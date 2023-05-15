using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float range;
    public float damage;
    //public Transform origin;
    LayerMask layermask;
    [SerializeField] List<RaycastHit> hits = new List<RaycastHit>();

    private void Start()
    {
        
    }

    private void Update()
    {


        if (Input.GetKey(KeyCode.T))
        {
            //Centre Line
            RaycastHit hit;
            var origin = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
            var direction = transform.TransformDirection(Vector3.forward);
            Physics.Raycast(origin, direction, out hit, range);
            Debug.DrawLine(origin, hit.point, Color.red);
            //Debug.Log(hit.collider);
            hits.Add(hit);

            //Line 1
            RaycastHit hit1;
            var origin1 = new Vector3(transform.localPosition.x + 2, transform.localPosition.y, transform.localPosition.z);
            var direction1 = transform.TransformDirection(Vector3.forward);
            Physics.Raycast(origin1, direction1, out hit1, range);
            Debug.DrawLine(origin1, hit1.point, Color.yellow);
           // Debug.Log(hit1.collider);
            hits.Add(hit1);

            //Line 2
            RaycastHit hit2;
            var origin2 = new Vector3(transform.localPosition.x + -2, transform.localPosition.y, transform.localPosition.z);
            var direction2 = transform.TransformDirection(Vector3.forward);
            Physics.Raycast(origin2, direction2, out hit2, range);
            Debug.DrawLine(origin2, hit2.point, Color.white);
           // Debug.Log(hit2.collider);
            hits.Add(hit2);

            ////Line 3
            //RaycastHit hit3;
            //var origin3 = new Vector3(transform.localPosition.x, transform.localPosition.y + 2, transform.localPosition.z);
            //var direction3 = transform.TransformDirection(Vector3.forward);
            //Physics.Raycast(origin3, direction3, out hit3, range);
            //Debug.DrawLine(origin3, hit3.point, Color.cyan);
            //Debug.Log(hit3.collider);

            ////Line 4
            //RaycastHit hit4;
            //var origin4 = new Vector3(transform.localPosition.x, transform.localPosition.y + -1, transform.localPosition.z);
            //var direction4 = transform.TransformDirection(Vector3.forward);
            //Physics.Raycast(origin4, direction4, out hit4, range);
            //Debug.DrawLine(origin4,hit4.point, Color.green);
            //Debug.Log(hit4.collider);

            //Line 2
            RaycastHit hit5;
           var origin5 = new Vector3(transform.localPosition.x , transform.localPosition.y, transform.localPosition.z + 2);
           var direction5 = transform.TransformDirection(Vector3.forward);
           Physics.Raycast(origin5, direction5, out hit5, range);
           Debug.DrawLine(origin5, hit5.point, Color.cyan);
           //Debug.Log(hit5.collider);
            hits.Add(hit5);

            //Line 2
            RaycastHit hit6;
           var origin6 = new Vector3(transform.localPosition.x , transform.localPosition.y, transform.localPosition.z + -2);
           var direction6 = transform.TransformDirection(Vector3.forward);
           Physics.Raycast(origin6, direction6, out hit6, range);
           Debug.DrawLine(origin6, hit6.point, Color.cyan);
           //Debug.Log(hit6.collider);
            hits.Add(hit6);


        }

        foreach (RaycastHit i in hits)
        {
            
            if (i.collider == null)
            { 
                return; 
            }
            else if (i.collider.tag == "Enemy")
            {
                Debug.Log("Beam Attack");
                i.collider.GetComponent<EnemyStats>().TakeDamage(damage);
            }
        }
    }
}

    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSpin : MonoBehaviour
{
    public float spinSpeed;


    private void Update()
    {
        transform.Rotate(new Vector3(0, spinSpeed, 0));
    }
}

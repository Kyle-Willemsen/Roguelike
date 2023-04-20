using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class TESTSO : ScriptableObject
{
    [SerializeField]
    private float roomsEntered;

    public float RoomsEntered
    {
        get { return roomsEntered; }
        set { this.roomsEntered = value; }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatsSO : ScriptableObject
{
    [SerializeField] private float playerHealth;
    public float PlayerHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; }
    }

    [SerializeField] private float maxHealth;
    public float PlayerMaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    [SerializeField] private float potionValue;
    public float PotionValue
    {
        get { return potionValue; }
        set { potionValue = value; }
    }

    [SerializeField] private int potionCounter;
    public int PotionCounter
    {
        get { return potionCounter; }
        set { potionCounter = value; }
    }


}

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

    [SerializeField] private float dashCooldwon;

    public float DashCooldwon
    {
        get { return dashCooldwon; }
        set { dashCooldwon = value; }
    }

    [SerializeField] private float baseMoveSpeed;

    public float BaseMoveSpeed
    {
        get { return baseMoveSpeed; }
        set { baseMoveSpeed = value; }
    }


    [SerializeField] private bool dashBomb;
    public bool DashBomb
    {
        get { return dashBomb; }
        set { dashBomb = value; }
    }

    [SerializeField] private bool invisibleAbility;
    public bool InvisibleAbility
    {
        get { return invisibleAbility; }
        set { invisibleAbility = value; }
    }

    [SerializeField] private bool teleportDash;
    public bool TeleportDash
    {
        get { return teleportDash; }
        set { teleportDash = value; }
    }
}

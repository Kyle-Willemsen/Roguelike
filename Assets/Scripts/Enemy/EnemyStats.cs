using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    GameManager manager;
    public float currentHealth;
    public float maxHealth;

    public GameObject souls;
    public GameObject fragments;
    public GameObject lootHP;
    private float soulMinDrop;
    private float soulMaxDrop;
    private float fragmentMinDrop;
    private float fragmentMaxDrop;
    public Transform lootDropPos;

    public bool soulsRoom;
    //[SerializeField] SingleValuesSO roomsEntered;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    private void Start()
    {
        manager.numberOfEnemiesLeft++;
        currentHealth = maxHealth;

        if (soulsRoom)
        {
            soulMinDrop = 2;
            soulMaxDrop = 8;
            fragmentMaxDrop = 0;
        }
        else
        {
            soulMinDrop = 0;
            soulMaxDrop = 6;
            fragmentMaxDrop = 6;
        }
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Dead();
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    private void Dead()
    {
        for (int i = 0; i < Random.Range(soulMinDrop, soulMaxDrop); i++)
        {
            var go = Instantiate(souls, lootDropPos.position + new Vector3(Random.Range(0, 3f), Random.Range(0.2f, 0)), Quaternion.identity);
            go.GetComponent<LootFollow>().target = souls.transform;
        }

        for (int i = 0; i < Random.Range(fragmentMaxDrop, fragmentMaxDrop); i++)
        {
            var go = Instantiate(fragments, lootDropPos.position + new Vector3(Random.Range(0, 3f), Random.Range(0.2f, 0)), Quaternion.identity);
            go.GetComponent<LootFollow>().target = souls.transform;
        }


        int chanceOfHPDrop = 1;
        if (Random.Range(0, 50) <= chanceOfHPDrop)
        {
            var got = Instantiate(lootHP, lootDropPos.position, Quaternion.identity);
        }
        manager.numberOfEnemiesLeft--;
        Destroy(gameObject);
    }
}

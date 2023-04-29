using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    GameManager manager;
    public float currentHealth;
    public float maxHealth;

    public GameObject lootCurrency;
    public GameObject lootHP;
    private float minDrop = 2;
    private float maxDrop = 6;
    public Transform lootDropPos;


    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        manager.numberOfEnemiesLeft++;
    }
    private void Start()
    {
        currentHealth = maxHealth;
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
        for (int i = 0; i < Random.Range(minDrop, maxDrop); i++)
        {
            var go = Instantiate(lootCurrency, lootDropPos.position + new Vector3(Random.Range(0, 3f), Random.Range(0.2f, 0)), Quaternion.identity);
            go.GetComponent<LootFollow>().target = lootCurrency.transform;
        }

        int chanceOfHPDrop = 1;
        if (Random.Range(0, 20) <= chanceOfHPDrop)
        {
            var got = Instantiate(lootHP, lootDropPos.position, Quaternion.identity);
        }
        manager.numberOfEnemiesLeft--;
        Destroy(gameObject);
    }
}

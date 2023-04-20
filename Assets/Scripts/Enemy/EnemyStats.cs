using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    GameManager manager;
    public float currentHealth;
    public float maxHealth;

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
            manager.numberOfEnemiesLeft--;
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}

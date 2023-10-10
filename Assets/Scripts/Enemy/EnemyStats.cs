using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    GameManager manager;
    //public HealthBar healthbar;
    public float currentHealth;
    public float maxHealth;
    public GameObject floatingText;

    public GameObject souls;
    public GameObject fragments;
    public GameObject lootHP;
    private float soulMinDrop;
    private float soulMaxDrop;
    private float fragmentMinDrop;
    private float fragmentMaxDrop;
    public Transform lootDropPos;

    public bool soulsRoom;

    public BoxCollider boxCollider;
    public GameObject spawnIcon;
    public GameObject mesh;
    //EnemyNavigation enemyNav;

    //[SerializeField] SingleValuesSO roomsEntered;

    private void Awake()
    {
        //enemyNav = GetComponent<EnemyNavigation>();
        boxCollider.enabled = false;
        mesh.SetActive(false);
        Invoke("SpawnEnemy", 1.4f);
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        

    }
    private void Start()
    {
       // healthbar.SetMaxHealth(maxHealth);
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
       // healthbar.SetHealth(currentHealth);
        
        var ft = Instantiate(floatingText, transform.position, Quaternion.identity, transform);
        ft.GetComponent<TextMesh>().text = damage.ToString();
    }

    public void SpawnEnemy()
    {
        //enemyNav.enabled = true;
        boxCollider.enabled = true;
        mesh.SetActive(true);
        Destroy(spawnIcon);
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
   // private void LateUpdate()
    //{
        //healthbar.transform.LookAt(Camera.main.transform);
        //healthbar.transform.Rotate(0, 180, 0);
    //}
}

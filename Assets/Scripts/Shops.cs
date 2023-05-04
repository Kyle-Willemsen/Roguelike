using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shops : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "PlayerUpgrades" && other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Player Upgrades");
        }

        if (gameObject.tag == "BeamUpgrades" && other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Beam Upgrades");
        }

        if (gameObject.tag == "ProjectileUpgrades" && other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Projectile Upgrades");
        }
    }
}

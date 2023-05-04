using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopSelectionRoom : MonoBehaviour
{
    [SerializeField] SingleValuesSO roomsEntered;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            roomsEntered.Value = 0f;
            SceneManager.LoadScene("ShopSelection");
        }
    }
}

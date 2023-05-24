using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveRoom : MonoBehaviour
{
    [SerializeField] SingleValuesSO roomsEntered;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Wave Room");
            roomsEntered.Value = 0f;
        }
    }
}

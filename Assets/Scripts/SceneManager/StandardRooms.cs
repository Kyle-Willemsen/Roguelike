using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StandardRooms : MonoBehaviour
{
    GameManager manager;
    [SerializeField]
    SingleValuesSO numberOfRoomsEntered;


    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            numberOfRoomsEntered.Value++;
            SceneManager.LoadScene(manager.randomScene);
        }
    }
}

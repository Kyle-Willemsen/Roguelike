using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestFoor : MonoBehaviour
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

            if (numberOfRoomsEntered.Value == 1 || numberOfRoomsEntered.Value == 10 || numberOfRoomsEntered.Value == 19)
            {
                SceneManager.LoadScene("Choice");
            }

            if (numberOfRoomsEntered.Value == 6 || numberOfRoomsEntered.Value == 15 || numberOfRoomsEntered.Value == 24)
            {
                SceneManager.LoadScene("PreWaveRoom");
            }

        }
    }
}

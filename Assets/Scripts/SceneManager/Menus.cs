using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject manual;

    public void StartGame()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1f;
    }

    public void Manual()
    {
        manual.SetActive(true);
    }

    public void UnselectManual()
    {
        manual.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

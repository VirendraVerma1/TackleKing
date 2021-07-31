using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public GameObject PausePannel;
    public GameObject GameOverPannel;
    public GameObject GameWonPannel;

    private void Start()
    {
        OffAllWindow();
    }
    public void OnGameWon()
    {
        GameWonPannel.SetActive(true);
    }

    public void OnGameOver()
    {
        GameOverPannel.SetActive(true);
    }

    public void OnGamePause()
    {
        PausePannel.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnGameResume()
    {
        Time.timeScale = 1;
        OffAllWindow();
    }

    public void OnGameRestart()
    {
        SceneManager.LoadScene(0);
    }

    void OffAllWindow()
    {
        PausePannel.SetActive(false);
        GameOverPannel.SetActive(false);
        GameWonPannel.SetActive(false);
    }
}

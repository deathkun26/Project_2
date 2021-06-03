using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public HUDController hud;
    public PlayerController player;
    public static bool isGameActive;
    public GameObject pauseMenu;
    void Start()
    {
        Debug.Log(StartGame.playerName);
        isGameActive = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGameActive)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        isGameActive = false;
        Debug.Log("Pause");
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        isGameActive = true;
        Debug.Log("Resume");
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartGame");
    }
}

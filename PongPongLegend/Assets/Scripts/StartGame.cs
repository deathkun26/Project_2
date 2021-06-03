using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public TMP_InputField inputField;
    public static string playerName = "None";

    void Start()
    {
        playerName = "Player";
    }

    public void UpdateName()
    {
        playerName = inputField.text;
        if (playerName == "")
            playerName = "Player";
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PlayGame");
    }
}

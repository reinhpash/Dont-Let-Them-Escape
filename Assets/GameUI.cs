using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickMenu()
    {
        PlayerPrefs.SetInt("Level", 0);
        SceneManager.LoadScene("MainMenu");
    }
}

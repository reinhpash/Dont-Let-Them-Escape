using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using UnityEngine.SceneManagement;

namespace GreatArcStudios
{
    
    public class PauseManager : MonoBehaviour
    {
        public GameObject mainPanel;
        
        public GameObject TitleTexts;

        public float timeScale = 1f;

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Resume()
        {
            Time.timeScale = timeScale;

            mainPanel.SetActive(false);
            TitleTexts.SetActive(false);
        }
        public void quitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        public void returnToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && mainPanel.gameObject.activeSelf == false)
            {
                mainPanel.SetActive(true);
                TitleTexts.SetActive(true);
                //Time.timeScale = 0;
            }
            else if(Input.GetKeyDown(KeyCode.Escape) && mainPanel.gameObject.activeSelf == true) {
                //Time.timeScale = timeScale;
                mainPanel.SetActive(false);
                TitleTexts.SetActive(false);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Level[] levels;

    int playerLevel = 0;

    public PlacementController placementController;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            playerLevel = PlayerPrefs.GetInt("Level");
        }
        else
        {
            playerLevel = 0;
            PlayerPrefs.SetInt("Level", 0);
        }
        SpawnLevel();
    }

    public void SpawnLevel()
    {
        var lvl = levels[playerLevel].levelPrefab;
        var obj = Instantiate(lvl) as GameObject;

        placementController.SetTraps(1, levels[playerLevel].hammerAmount);
        placementController.SetTraps(2, levels[playerLevel].spinnerAmount);
        placementController.SetTraps(3, levels[playerLevel].sutunSpinnerAmount);
        placementController.SetTraps(4, levels[playerLevel].SpikeWallAmount);

    }

    public void NextLevel()
    {
        int value = playerLevel += 1;
        if (value == levels.Length)
        {
            SceneManager.LoadScene("End");
        }
        else
        {
            PlayerPrefs.SetInt("Level", value);

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

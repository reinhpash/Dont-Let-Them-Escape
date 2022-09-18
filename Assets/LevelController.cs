using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject HeroSpawner;
    public GameObject startCanvas;

    public void StartLevel()
    {
        HeroSpawner.SetActive(true);
        startCanvas.SetActive(false);
        GameController.instance.StartLevel();
    }

    private void Start()
    {
        GameController.instance.SetSpawner(HeroSpawner.GetComponent<HeroSpawner>());
    }
}

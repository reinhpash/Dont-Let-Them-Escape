using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject winPanel;
    public GameObject losePanel;

    public GameObject UI;
    public HeroSpawner heroSpawner;
    public FinalTrigger finalTrigger;

    bool spawnComplete;
    int limit;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (heroSpawner != null)
        {
            if (heroSpawner.heroList.Count > 0)
            {
                spawnComplete = true;
            }
        }
        if (spawnComplete)
        {
            Debug.Log(finalTrigger.currentHero < limit);
            Debug.Log(heroSpawner.heroList.Count <= 0);
            if (heroSpawner.heroList.Count <= 0 && finalTrigger.currentHero <= limit)
            {
                if (winPanel.activeSelf == false)
                {
                    winPanel.SetActive(true);
                }
                
            }
            else if (heroSpawner.heroList.Count <= 0 && finalTrigger.currentHero > limit)
            {
                if (losePanel.activeSelf == false)
                {
                    losePanel.SetActive(true);
                }
                
            }
        }
    }

    public void SetSpawner(HeroSpawner spawner)
    {
        heroSpawner = spawner;
    }

    public void SetFinalTrigger(FinalTrigger trigger)
    {
        finalTrigger = trigger;
        limit = finalTrigger.succesLimit;
    }

    public void StartLevel()
    {
        UI.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSpawner : MonoBehaviour
{
    public GameObject hero;

    public int lvl1Amount = 1;
    public int lvl2Amount = 1;
    public int lvl3Amount = 1;

    public List<GameObject> heroList = new List<GameObject>();

    bool spawnComplete = false;

    public bool mainMenuSpawner = false;

    float spawnDelay = 1.5f;
    float curTime;


    private void Start()
    {
        Spawn();
        if (mainMenuSpawner)
        {
            StartCoroutine("Spawner");
        }
    }

    public void OnClickStart()
    {
        Spawn();
    }


    void Spawn()
    {
        if (!mainMenuSpawner)
        {
            for (int i = 0; i < lvl1Amount; i++)
            {
                var obj = Instantiate(hero, this.transform.position, Quaternion.identity);
                heroList.Add(obj);
            }

            for (int i = 0; i < lvl2Amount; i++)
            {
                var obj = Instantiate(hero, this.transform.position, Quaternion.identity);
                obj.GetComponentInChildren<HeroAI>().level = 2;
                heroList.Add(obj);
            }

            for (int i = 0; i < lvl3Amount; i++)
            {
                var obj = Instantiate(hero, this.transform.position, Quaternion.identity);
                obj.GetComponentInChildren<HeroAI>().level = 3;
                heroList.Add(obj);
            }

            spawnComplete = true;
        }
    }

    IEnumerator Spawner()
    {
        while (true) {
            for (int i = 0; i < 5; i++)
            {
                var obj = Instantiate(hero, this.transform.position, Quaternion.identity);
                obj.GetComponentInChildren<HeroAI>().level = Random.Range(1, 4);
                heroList.Add(obj);
            }
            yield return new WaitForSeconds(2f);
        }
    }
}

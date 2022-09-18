using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalTrigger : MonoBehaviour
{
    [HideInInspector]public int currentHero = 0;
    public int succesLimit = 2;

    public TextMeshProUGUI limitText;

    private void Start()
    {
        SetText();

        GameController.instance.SetFinalTrigger(this);
    }

    private void SetText()
    {
        if (currentHero == succesLimit / 2)
        {
            limitText.color = Color.red;
        }
        limitText.SetText(currentHero + "/" + succesLimit);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            currentHero++;
            SetText();
            var obj = GameObject.FindGameObjectWithTag("HeroSpawner");
            if (obj.GetComponent<HeroSpawner>().heroList.Contains(other.transform.parent.gameObject))
                obj.GetComponent<HeroSpawner>().heroList.Remove(other.transform.parent.gameObject);
            Destroy(other.transform.parent.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class RandomText : MonoBehaviour
{
    public string[] texts;

    public TextMeshProUGUI text;

    private void Start()
    {
        text.SetText(texts[Random.Range(0, texts.Length - 1)]);
        this.transform.localScale = Vector3.zero;
        this.transform.DOScale(Vector3.one, 1);
    }
}

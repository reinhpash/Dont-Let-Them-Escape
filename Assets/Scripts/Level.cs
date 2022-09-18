using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelManager", order = 1)]
public class Level : ScriptableObject
{
    public GameObject levelPrefab;
    public int l1Amount = 1;
    public int l2Amount = 0;
    public int l3Amount = 0;

    public int hammerAmount = 1;
    public int spinnerAmount = 1;
    public int sutunSpinnerAmount = 1;
    public int SpikeWallAmount = 1;

    public int successLimit = 2;
}

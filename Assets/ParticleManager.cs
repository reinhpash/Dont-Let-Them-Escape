using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public static ParticleManager Instance;
    public GameObject explodeEffect;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayExploadeEffect(Vector3 pos, Material mat)
    {
        var obj = Instantiate(explodeEffect);
        obj.GetComponent<ParticleSystemRenderer>().material = mat;
        obj.transform.position = pos;
    }
}

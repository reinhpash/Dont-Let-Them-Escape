using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    bool canPlace = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            Debug.Log("??");
        }
    }
}

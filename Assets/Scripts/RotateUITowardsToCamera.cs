using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUITowardsToCamera : MonoBehaviour
{
    public Transform mLookAt;
    private Transform localTransform;

    private void Start()
    {
        localTransform = this.GetComponent<Transform>();
        mLookAt = Camera.main.transform;
    }

    private void Update()
    {
        if (mLookAt != null)
        {
            localTransform.LookAt(2* localTransform.position - mLookAt.position);
        }
    }
}

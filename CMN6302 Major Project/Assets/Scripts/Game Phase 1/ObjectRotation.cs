using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public GameObject thisObject, rotationTarget;
    public float rotationSpeed;
    public bool rotateAround = false;

    // Update is called once per frame
    void Update()
    {
        if (!rotateAround)
        {
            // Spin the object at chosen speed.
            thisObject.transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
        }
        else
        {
            // Spin the object around the target at chosen speed.
            thisObject.transform.RotateAround(rotationTarget.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }

    }
}

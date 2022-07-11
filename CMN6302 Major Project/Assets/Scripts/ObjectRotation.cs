using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public GameObject target;
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        // Spin the object around the target at 20 degrees/second.
        target.transform.Rotate(0.0f, rotationSpeed, 0.0f);
    }
}

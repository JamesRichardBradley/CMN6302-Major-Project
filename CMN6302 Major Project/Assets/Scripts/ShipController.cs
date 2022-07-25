using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private CharacterController cc;
    public float speed = 0.0f;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        cc.Move(movement * Time.deltaTime * speed);


        Vector3 desiredPosition = transform.position + movement;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);

        cc.transform.LookAt(smoothedPosition);
    }
}
 
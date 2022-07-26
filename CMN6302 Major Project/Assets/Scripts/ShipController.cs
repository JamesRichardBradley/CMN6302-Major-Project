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
        // Defines the speed and direction the ship is travelling in
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        cc.Move(movement * Time.deltaTime * speed);

        // Takes the current position, and the direction of travel, and smoothly rotates the player towards the direction of travel
        Vector3 desiredPosition = transform.position + movement;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        cc.transform.LookAt(smoothedPosition);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Planet"))
    //    {
    //        Debug.Log("In Planetary Range");
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Planet"))
    //    {
    //        Debug.Log("Left Planetary Range");
    //    }
    //}
}
 
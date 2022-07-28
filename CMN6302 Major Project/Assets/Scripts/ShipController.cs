using UnityEngine;

public class ShipController : MonoBehaviour
{
    private CharacterController cc;
    public float speed = 0.0f;
    public bool paused = false;
    UiManagment userInterface;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        userInterface = GameObject.Find("SolarSystemManagement").GetComponent<UiManagment>();
    }

    private void Update()
    {
        paused = userInterface.paused;

        if (!paused)
        {
            // Defines the speed and direction the ship is travelling in
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            cc.Move(movement * Time.deltaTime * speed);

            // Takes the current position, and the direction of travel, and smoothly rotates the player towards the direction of travel
            Vector3 desiredPosition = transform.position + movement;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
            cc.transform.LookAt(smoothedPosition);
        }
    }
}
 
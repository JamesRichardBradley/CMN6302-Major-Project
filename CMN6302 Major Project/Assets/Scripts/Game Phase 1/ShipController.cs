using UnityEngine;

public class ShipController : MonoBehaviour
{
    private CharacterController cc;
    public float speed = 0.0f;
    public bool paused = false;

    UiManagment userInterface;
    SolarSytemManagement systemDetails;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        userInterface = GameObject.Find("SolarSystemManagement").GetComponent<UiManagment>();
        systemDetails = GameObject.Find("SolarSystemManagement").GetComponent<SolarSytemManagement>();
    }

    private void Update()
    {
        // Retrieves the status of "Paused" in the UI script, and makes sure this script matches it.
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

            // Calculates the distance between the center of the system, and the players current position.
            float playerDistance = Vector3.Distance(Vector3.zero, transform.position);

            // Calculates the distance between the center of the system, and the last planet generated
            float planetDistance = Vector3.Distance(Vector3.zero, systemDetails.planet.transform.position);

            // Compares the position of the player and the position of the furthest planet, and clamps the players maximum distance to match the furthest planet.
            // This stops the player from endlessly travelling into the void and becoming lost.
            if (playerDistance >= (planetDistance))
            {
                Vector3 vect = Vector3.zero - transform.position;
                vect = vect.normalized;
                vect *= playerDistance - planetDistance;
                transform.position += vect;
            }
        }
    }
}
 
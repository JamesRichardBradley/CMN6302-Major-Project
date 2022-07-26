using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public GameObject scanCircle;
    private GameObject player;
    private LineRenderer circleRenderer;
    private Vector3 target;
    public Camera planetCamera;

    private void Start()
    {
        // Sets up camera's, player, and scan circle on start.
        player = GameObject.FindGameObjectWithTag("Player");
        planetCamera.enabled = false;
        scanCircle.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Makes the scan circle appear when player enters trigger zone.
        if (other.CompareTag("Player"))
        {
            scanCircle.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // While the player is within the trigger zone of the planet, pressing the "Submit" button allows them to enter "Planetary View"
        if (Input.GetButton("Submit"))
        {
            Debug.Log("Button Pressed");
            circleRenderer = this.gameObject.GetComponent<LineRenderer>();
            planetCamera.enabled = true;
            scanCircle.SetActive(false);
            player.SetActive(false);
            circleRenderer.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Makes the scan circle disappear when player leaves trigger zone.
        if (other.CompareTag("Player"))
        {
            scanCircle.SetActive(false);
        }
    }

    private void Update()
    {
        // Makes the scan circle always face the camera.
        target = Camera.main.transform.position;
        scanCircle.transform.LookAt(target);

        // Allows player to exit Planetary View, and return to the system map
        if (Input.GetButton("Cancel"))
        {
            Debug.Log("Button Pressed");
            circleRenderer = this.gameObject.GetComponent<LineRenderer>();
            planetCamera.enabled = false;
            player.SetActive(true);
            circleRenderer.enabled = true;
        }
    }
}

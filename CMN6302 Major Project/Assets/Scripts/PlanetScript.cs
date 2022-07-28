using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public GameObject scanCircle;
    public LineRenderer circleRenderer;
    public Camera planetCamera;
    private GameObject player;
    private Vector3 target;

    UiManagment userInterface;
    public bool isMissionPlanet, paused;

    private void Start()
    {
        GetGameObjects();
        SetGameObjectsDefaults();
    }

    private void GetGameObjects()
    {
        player = GameObject.Find("Player");
        userInterface = GameObject.Find("SolarSystemManagement").GetComponent<UiManagment>();
    }

    private void SetGameObjectsDefaults()
    {
        planetCamera.enabled = false;
        scanCircle.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!paused)
        {
            // Makes the scan circle appear when player enters trigger zone.
            if (other.CompareTag("Player"))
            {
                scanCircle.SetActive(true);
                userInterface.SetUIMode(1);

                // Makes the scan circle always face the camera.
                target = Camera.main.transform.position;
                scanCircle.transform.LookAt(target);

                Debug.Log("Player has entered Trigger");
            }

            // While the player is within the trigger zone of the planet, pressing the "Submit" button allows them to enter "Planetary View"
            if (Input.GetButton("Submit"))
            {
                circleRenderer = this.gameObject.GetComponent<LineRenderer>();
                circleRenderer.enabled = false;
                planetCamera.enabled = true;
                scanCircle.SetActive(false);
                player.SetActive(false);
                Debug.Log("Select Pressed");

                // Selects which UI is displayed dependent on whether the planet contains the mission objective.
                if (isMissionPlanet)
                {
                    userInterface.SetUIMode(2);
                    Debug.Log("Mission Planet");
                }
                else
                {
                    userInterface.SetUIMode(3);
                    Debug.Log("Not Mission Planet");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Makes the scan circle disappear when player leaves trigger zone.
        if (other.CompareTag("Player"))
        {
            scanCircle.SetActive(false);
            userInterface.SetUIMode(0);
        }
    }

    private void Update()
    {
        paused = userInterface.paused;

        if(!paused)
        {
            // Allows player to exit Planetary View, and return to the system map
            if (Input.GetButton("Cancel"))
            {
                circleRenderer = this.gameObject.GetComponent<LineRenderer>();
                planetCamera.enabled = false;
                player.SetActive(true);
                circleRenderer.enabled = true;
                Debug.Log("Back Pressed");
            }
        }
    }
}

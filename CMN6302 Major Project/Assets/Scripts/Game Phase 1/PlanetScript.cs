using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public GameObject scanCircle;
    public LineRenderer circleRenderer;
    public Camera planetCamera;
    public GameObject player, walkPlayer;
    private Vector3 target;

    UiManagment userInterface;
    SolarSytemManagement systemSettings;
    public bool isMissionPlanet, paused;
    public float gravity = -12;

    private void Start()
    {
        GetGameObjects();
        SetGameObjectsDefaults();
    }

    private void GetGameObjects()
    {
        player = GameObject.Find("PlayerShip");
        userInterface = GameObject.Find("SolarSystemManagement").GetComponent<UiManagment>();
        systemSettings = GameObject.Find("SolarSystemManagement").GetComponent<SolarSytemManagement>();
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
            if (Input.GetButton("Submit") && userInterface.uiMode != 2)
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
        // Retrieves the status of "Paused" in the UI script, and makes sure this script matches it.
        paused = userInterface.paused;

        if (Input.GetButton("Submit") && userInterface.uiMode == 2)
        {
            planetCamera.enabled = false;
            systemSettings.surfacePlayer.SetActive(true);
            userInterface.SetUIMode(5);
        }

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

    public void Attract(Transform playerTransform)
    {
        Vector3 gravityUp = (playerTransform.position - transform.position).normalized;
        Vector3 localUp = playerTransform.up;

        playerTransform.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50.0f * Time.deltaTime);
    }
}

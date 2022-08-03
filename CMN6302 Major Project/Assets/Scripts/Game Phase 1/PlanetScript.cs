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
    public float gravity = -12, cooldownTimer, time = 0.5f;
    private int uiMode;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scanCircle.SetActive(true);
            userInterface.SetUIMode(1);
            target = Camera.main.transform.position;
            scanCircle.transform.LookAt(target);
            Debug.Log("Player has entered Trigger");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!paused)
        {
            if (Input.GetButton("Submit") && cooldownTimer >= time)
            {
                switch (uiMode)
                {
                    case 1:
                        circleRenderer = GetComponent<LineRenderer>();
                        circleRenderer.enabled = false;
                        planetCamera.enabled = true;
                        scanCircle.SetActive(false);
                        player.SetActive(false);
                        Debug.Log("Select Pressed");

                        if (!isMissionPlanet)
                        {
                            userInterface.SetUIMode(3);
                            Debug.Log("Not Mission Planet");
                        }
                        else
                        {
                            userInterface.SetUIMode(2);
                            Debug.Log("Mission Planet");
                        }
                        break;

                    case 2:
                        planetCamera.enabled = false;
                        systemSettings.surfacePlayer.SetActive(true);
                        userInterface.SetUIMode(5);
                        break;
                }

                cooldownTimer = 0;
            }

            if (Input.GetButton("Cancel") && cooldownTimer >= time)
            {
                if (uiMode != 5)
                {
                    circleRenderer = GetComponent<LineRenderer>();
                    planetCamera.enabled = false;
                    player.SetActive(true);
                    circleRenderer.enabled = true;
                    Debug.Log("Back Pressed");
                }

                cooldownTimer = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scanCircle.SetActive(false);
            userInterface.SetUIMode(0);
            Debug.Log("Player has left Trigger");
        }
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        paused = userInterface.paused;
        uiMode = userInterface.uiMode;
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

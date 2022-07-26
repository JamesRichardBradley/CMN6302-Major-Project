using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public GameObject scanCircle;
    private Vector3 target;

    // Makes the scan circle invisible on load.
    private void Start()
    {
        scanCircle.SetActive(false);
    }

    // Makes the scan circle always face the camera.
    private void Update()
    {
        target = Camera.main.transform.position;
        scanCircle.transform.LookAt(target);
    }

    // Makes the scan circle appear when player enters trigger zone.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scanCircle.SetActive(true);
        }
    }

    // Makes the scan circle disappear when player leaves trigger zone.
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scanCircle.SetActive(false);
        }
    }

}

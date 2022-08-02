using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityScript : MonoBehaviour
{
    public PlanetScript gravityPlanet;
    private Transform playerTransform;

    SolarSytemManagement systemSettings;

    // Start is called before the first frame update
    void Start()
    {
        systemSettings = GameObject.Find("SolarSystemManagement").GetComponent<SolarSytemManagement>();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        playerTransform = transform;

        gravityPlanet = systemSettings.missionPlanet;
    }

    void FixedUpdate()
    {
        if (gravityPlanet)
        {
            gravityPlanet.Attract(playerTransform);
        }
    }
}

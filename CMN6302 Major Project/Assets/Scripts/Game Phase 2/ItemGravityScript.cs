using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGravityScript : MonoBehaviour
{
    public PlanetScript gravityPlanet;
    private Transform itemTransform;

    SolarSytemManagement systemSettings;

    // Start is called before the first frame update
    void Start()
    {
        systemSettings = GameObject.Find("SolarSystemManagement").GetComponent<SolarSytemManagement>();
        GetComponent<Rigidbody>().useGravity = false;

        itemTransform = transform;

        gravityPlanet = systemSettings.missionPlanet;
    }

    void FixedUpdate()
    {
        if (gravityPlanet)
        {
            gravityPlanet.Attract(itemTransform);
        }
    }
}

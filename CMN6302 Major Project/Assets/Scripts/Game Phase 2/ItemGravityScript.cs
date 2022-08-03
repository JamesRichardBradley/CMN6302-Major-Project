using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGravityScript : MonoBehaviour
{
    public PlanetScript gravityPlanet;
    private Transform itemTransform;

    SolarSytemManagement systemSettings;

    void Start()
    {
        //  Obtains the mission planet from SolarSystemManagment, and ensures the gravity is applied to only that planet
        systemSettings = GameObject.Find("SolarSystemManagement").GetComponent<SolarSytemManagement>();
        gravityPlanet = systemSettings.missionPlanet;

        //  Gets the rigidbody for this GameObject, and turns off the Unity World gravity
        GetComponent<Rigidbody>().useGravity = false;
        itemTransform = transform;
    }

    void FixedUpdate()
    {
        //  If this GameObject is on the mission planet, Attract this GameObject to the mission planet (Faux Gravity)
        if (gravityPlanet)
        {
            gravityPlanet.Attract(itemTransform);
        }
    }
}

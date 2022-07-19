using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSytemManagement : MonoBehaviour
{
    public Material[] skyboxMaterials;
    public GameObject[] systemCenterList;
    private GameObject systemCenter;
    private int centerSelection, totalPlanets;
    private float distance = 30.0f, randomDistance, scaleFactor;
    private Vector3 scale;


    // Start is called before the first frame update
    void Start()
    {
        Randomization();    
        SkyboxSetup();
        SystemCenterSetup();
        PlanetGeneration();
    }

    void Randomization()
    {
        centerSelection = Random.Range(0, systemCenterList.Length);
        totalPlanets = Random.Range(1, 6);
    }

    void SkyboxSetup()
    {
        //Selects the skybox to be used for this iteration of the game
        RenderSettings.skybox = skyboxMaterials[Random.Range(0, skyboxMaterials.Length)];
    }

    void SystemCenterSetup()
    {
        //Selects what will be generated for the gravitational point of the system (Star, Binary System, or Black Hole)
        systemCenter = systemCenterList[centerSelection];
        Instantiate(systemCenter, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void PlanetGeneration()
    {
        // For Loop to iterate through the designated number of planets
        for (int currentPlanet = 0; currentPlanet <= totalPlanets; currentPlanet++)
        {
            // Sets the scaling, and applies it to a Vector3, each planet will be a different size
            scaleFactor = Random.Range(1.0f, 5.0f);
            scale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

            // Creates a sphere (temporary), then sets its size, position (relative to the center and other generated planets), and its position in orbit around the center.
            GameObject planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            planet.transform.localScale += scale;
            planet.transform.position = new Vector3(0,0,distance);
            planet.transform.RotateAround(systemCenter.transform.position, Vector3.up, Random.Range(0, 359));

            // Adds the "DrawOrbit" script to the planet
            planet.AddComponent<DrawOrbit>();

            // Regenerates the distance so that planets aren't generated too close to eachother
            randomDistance = Random.Range(30, 45);
            distance += randomDistance;
        }
    }
}
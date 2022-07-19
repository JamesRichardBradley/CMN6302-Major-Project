using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSytemManagement : MonoBehaviour
{
    public Material[] skyboxMaterials;
    public GameObject[] systemCenterList;
    private GameObject systemCenter;
    public LineRenderer circleRenderer;
    private int centerSelection, totalPlanets;
    private float distance = 30.0f, randomDistance;


    // Start is called before the first frame update
    void Start()
    {
        Randomization();        
        SkyboxSetup();
        SystemCenterSetup();
    }

    void Randomization()
    {
        centerSelection = Random.Range(0, systemCenterList.Length);
        totalPlanets = Random.Range(0, 6);
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
        DrawCircle(60, distance);
    }

    void PlanetGeneration()
    {
        for (int currentPlanet = 0; currentPlanet <= totalPlanets; currentPlanet++)
        {
            GameObject planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            planet.transform.position = new Vector3(0,0,distance);
            planet.transform.
        }
    }

    //Function to draw orbital lines
    void DrawCircle(int steps, float radius)
    {
        circleRenderer.positionCount = steps + 1;

        for (int currentStep = 0; currentStep <= steps; currentStep++)
        {
            float progress = ((float)currentStep / steps);

            float radian = progress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(radian);
            float zScaled = Mathf.Sin(radian);

            float x = xScaled * radius;
            float z = zScaled * radius;

            Vector3 position = new Vector3(x, 0, z);

            circleRenderer.SetPosition(currentStep, position);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSytemManagement : MonoBehaviour
{
    public Material[] skyboxMaterials;
    public Material systemCenterMaterial;

    public GameObject[] systemCenter;
    public GameObject gravitationalPoint;

    public int centerSelection;

    public float radius;
    public float lineWidth;


    // Start is called before the first frame update
    void Start()
    {
        SkyboxSetup();
        SystemCenterSetup();
    }

    void SkyboxSetup()
    {
        //Selects the skybox to be used for this iteration of the game
        RenderSettings.skybox = skyboxMaterials[Random.Range(0, skyboxMaterials.Length)];
    }

    void SystemCenterSetup()
    {
        //Selects what will be generated for the gravitational point of the system (Star, Binary System, or Black Hole)
        centerSelection = Random.Range(0, systemCenter.Length);
        Instantiate(systemCenter[centerSelection], new Vector3(0, 0, 0), Quaternion.identity);
    }

    void DrawCircle()
    {
        var segments = 360;
        var line = gravitationalPoint.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.positionCount = segments + 1;

        var pointCount = segments + 1; // add extra point to make startpoint and endpoint the same to close the circle
        var points = new Vector3[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius, 0, Mathf.Cos(rad) * radius);
        }

        line.SetPositions(points);
    }

}



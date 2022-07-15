using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSytemManagement : MonoBehaviour
{
    public Material[] skyboxMaterials;
    public Material systemCenterMaterial;
    public GameObject[] systemCenter;
    public int centerSelection;

    // Start is called before the first frame update
    void Start()
    {
        skyboxSetup();
        systemCenterSetup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void skyboxSetup()
    {
        RenderSettings.skybox = skyboxMaterials[Random.Range(0, skyboxMaterials.Length)];
    }

    void systemCenterSetup()
    {
        centerSelection = Random.Range(0, systemCenter.Length);
        Instantiate(systemCenter[centerSelection], new Vector3(0, 0, 0), Quaternion.identity);
    }
}

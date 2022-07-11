using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSytemManagement : MonoBehaviour
{
    public Material[] skyboxMaterials;
    public GameObject systemCenter;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = skyboxMaterials[Random.Range(0, skyboxMaterials.Length)];
        Instantiate(systemCenter, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

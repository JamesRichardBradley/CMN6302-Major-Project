using UnityEngine;

public class SolarSytemManagement : MonoBehaviour
{
    public Material[] skyboxMaterials;
    public GameObject[] systemCenterList, instantiatedPlanets;
    public PlanetScript missionPlanet;
    public GameObject systemCenter, planet, planetContainer, walkPlayer, surfacePlayer;
    private int centerSelection, totalPlanets, skyboxSelection;
    public float distance = 50.0f, randomDistance;

    // Start is called before the first frame update
    void Start()
    {  
        SkyboxSetup();
        SystemCenterSetup();
        PlanetGeneration();
        MissionSetup();
        SurfacePlayerSetup();
    }

    void SkyboxSetup()
    {
        // Selects which skybox will be used for this game
        skyboxSelection = Random.Range(0, skyboxMaterials.Length);
        RenderSettings.skybox = skyboxMaterials[skyboxSelection];
        Debug.Log("Skybox Selected: " + skyboxSelection);
    }

    void SystemCenterSetup()
    {
        //Selects what will be generated for the gravitational point of the system (Star, Binary System, or Black Hole)
        centerSelection = Random.Range(0, systemCenterList.Length);
        Debug.Log("Gravitational Point Selected: " + centerSelection);
        systemCenter = systemCenterList[centerSelection];
        Instantiate(systemCenter, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log("System Center " + centerSelection + " Instantiated");
    }

    void PlanetGeneration()
    {
        totalPlanets = Random.Range(3, 8);

        Debug.Log("Number of Planets to Generate: " + totalPlanets);

        // For Loop to iterate through the designated number of planets
        for (int currentPlanet = 0; currentPlanet <= totalPlanets; currentPlanet++)
        {
            // Instantiates the Planet Container Prefab, and sets it's position (relative to the center and other generated planets), and its position in orbit around the center.
            planet = Instantiate(planetContainer);
            planet.transform.position = new Vector3(0,0,distance);
            planet.transform.RotateAround(systemCenter.transform.position, Vector3.up, Random.Range(0, 359));

            // Adds the "DrawOrbit" script to the planet
            planet.AddComponent<DrawOrbit>();

            // Regenerates the distance so that planets aren't generated too close to eachother
            randomDistance = Random.Range(30, 50);
            distance += randomDistance;

            planet.gameObject.tag = "Planet";

            Debug.Log("Planet " + (currentPlanet + 1) + " Generated");
        }
    }

    void MissionSetup()
    {
        // Adds all the created planets to an array, and selects one randomly to contain the mission objective.
        instantiatedPlanets = GameObject.FindGameObjectsWithTag("Planet");
        Debug.Log("instantiatedPlanets = " + instantiatedPlanets.Length);
        int chosenMissionPlanet = Random.Range(0, totalPlanets);
        missionPlanet = instantiatedPlanets[chosenMissionPlanet].GetComponent<PlanetScript>();
        missionPlanet.isMissionPlanet = true;
    }

    void SurfacePlayerSetup()
    {
        // Gets the Surface Walking player in place over the mission planet, ready for planetside gameplay
        surfacePlayer = Instantiate(walkPlayer, new Vector3(missionPlanet.transform.position.x, 1.2f, missionPlanet.transform.position.z), Quaternion.identity);
        surfacePlayer.SetActive(false);
    }
}
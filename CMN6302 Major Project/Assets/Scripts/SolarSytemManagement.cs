using UnityEngine;

public class SolarSytemManagement : MonoBehaviour
{
    public Material[] skyboxMaterials, planetMaterials;
    public GameObject[] systemCenterList, planetList, instantiatedPlanets;
    private PlanetScript missionPlanet;
    private GameObject systemCenter, planet;
    private MeshRenderer[] planetMeshes;
    private int centerSelection, totalPlanets, skyboxSelection, materialSelection;
    private float distance = 50.0f, randomDistance;

    // Start is called before the first frame update
    void Start()
    {  
        SkyboxSetup();
        SystemCenterSetup();
        PlanetGeneration();
    }

    // Selects which skybox will be used for this game
    void SkyboxSetup()
    {
        skyboxSelection = Random.Range(0, skyboxMaterials.Length);
        RenderSettings.skybox = skyboxMaterials[skyboxSelection];
        Debug.Log("Skybox Selected: " + skyboxSelection);
    }

    //Selects what will be generated for the gravitational point of the system (Star, Binary System, or Black Hole)
    void SystemCenterSetup()
    {
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
            materialSelection = Random.Range(0, planetMaterials.Length);

            // Creates a sphere (temporary), then sets its size, position (relative to the center and other generated planets), and its position in orbit around the center.
            planet = Instantiate(planetList[Random.Range(0, planetList.Length)]);
            planet.transform.position = new Vector3(0,0,distance);
            planet.transform.RotateAround(systemCenter.transform.position, Vector3.up, Random.Range(0, 359));

            // Finds all of the Mesh Renderers within the instantiated mesh, then applies a randomly chosen material to all meshes for this planet.
            planetMeshes = planet.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in planetMeshes)
            {
                renderer.material = planetMaterials[materialSelection];
            }

            // Adds the "DrawOrbit" script to the planet
            planet.AddComponent<DrawOrbit>();

            // Regenerates the distance so that planets aren't generated too close to eachother
            randomDistance = Random.Range(30, 50);
            distance += randomDistance;

            planet.gameObject.tag = "Planet";

            Debug.Log("Planet " + (currentPlanet + 1) + " Generated");
        }

        // Adds all the created planets to an array, and selects one randomly to contain the mission objective.
        instantiatedPlanets = GameObject.FindGameObjectsWithTag("Planet");
        Debug.Log("instantiatedPlanets = " + instantiatedPlanets.Length);
        missionPlanet = instantiatedPlanets[Random.Range(0, totalPlanets)].GetComponent<PlanetScript>();
        missionPlanet.isMissionPlanet = true;
    }
}
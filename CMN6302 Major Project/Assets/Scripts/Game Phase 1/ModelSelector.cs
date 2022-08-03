using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSelector : MonoBehaviour
{
    public GameObject container, planetModel;
    public GameObject[] modelList;
    public Mesh[] meshes;
    public Material[] planetMaterials;
    private int materialSelection;

    void Start()
    {
        SelectPlanetModel();
        CombineMeshes();
        SetPlanetTexture();
    }

    void SelectPlanetModel()
    {
        //  Instantiates a random model from the array, then matches its position to its container, then parents the container to the model
        planetModel = Instantiate(modelList[Random.Range(0, modelList.Length)]);
        planetModel.transform.localPosition = container.transform.position;
        planetModel.transform.parent = container.transform;
    }

    void CombineMeshes()
    {
        //  Gets all meshes present within the container and adds them to an array, then creates an array ready for later combination of meshes
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        //  For each mesh in the meshFilters array, add this to the combine array and set its positioning to match the original meshes
        for (int i = 0; i < meshFilters.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = transform.worldToLocalMatrix * meshFilters[i].transform.localToWorldMatrix;
        }

        //  Adds a MeshFilter, MeshRenderer, and Mesh Collider to the container
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        gameObject.AddComponent<MeshCollider>();

        //  Creates a new blank mesh, then combines the previous meshes into the new one as a single mesh
        transform.GetComponent<MeshFilter>().mesh = new Mesh(); ;
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);

        //  Assigns the newly combined mesh to the Mesh Collider, and ensures the new mesh is active in place of the old ones
        transform.GetComponent<MeshCollider>().sharedMesh = transform.GetComponent<MeshFilter>().mesh;
        transform.gameObject.SetActive(true);

        //  Destroys the previous meshes
        Destroy(planetModel);
    }

    void SetPlanetTexture()
    {
        // Selects a random material to be applied to the mesh
        materialSelection = Random.Range(0, planetMaterials.Length);

        // Finds all of the Mesh Renderers within the instantiated mesh, then applies the chosen material to all meshes for this planet.
        GetComponent<MeshRenderer>().material = planetMaterials[materialSelection];
    }
}

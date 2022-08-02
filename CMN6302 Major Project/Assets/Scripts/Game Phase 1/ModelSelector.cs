using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSelector : MonoBehaviour
{
    public GameObject container, planetModel;
    public GameObject[] modelList;
    public Mesh[] meshes;
    public Material[] planetMaterials;
    private MeshRenderer[] planetRenderers;
    private int materialSelection;

    void Start()
    {
        // Selects a random material to be applied to the mesh
        materialSelection = Random.Range(0, planetMaterials.Length);

        // Instantiates a random model from the array, then matches its position to its container, then parents the container to the model
        planetModel = Instantiate(modelList[Random.Range(0, modelList.Length)]);

        planetModel.transform.localPosition = container.transform.position;
        planetModel.transform.parent = container.transform;

        // Finds all of the Mesh Renderers within the instantiated mesh, then applies the chosen material to all meshes for this planet.
        planetRenderers = planetModel.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in planetRenderers)
        {
            renderer.material = planetMaterials[materialSelection];
        }
    }
}

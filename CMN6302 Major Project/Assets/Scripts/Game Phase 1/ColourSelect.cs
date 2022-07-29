using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSelect : MonoBehaviour
{
    private Material material;
    private float colourSelection;

    // Start is called before the first frame update
    void Start()
    {
        colourSelection = Random.Range(0.00f, 1.00f);
        material = GetComponent<MeshRenderer>().sharedMaterial;
        material.SetFloat("_BaseColour", colourSelection);
    }
}

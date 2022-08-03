using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyGenerationScript : MonoBehaviour
{
    public GameObject anomalyPrefab, anomaly;
    private int anomaliesToGenerate;

    private void Start()
    {
        //  Loads the Anomaly GameObject from the Resources folder
        anomalyPrefab = (GameObject)Resources.Load("Anomaly");
        AnomalyGeneration();
    }

    void AnomalyGeneration()
    {
        //  Decides how many Anomalies are to be generated across the planet
        anomaliesToGenerate = Random.Range(16, 24);

        //  Generates a new Anomaly at a random location on the planet, until it reaches the number set in "anomaliesToGenerate"
        for (int currentAnomaly = 0; currentAnomaly <= anomaliesToGenerate; currentAnomaly++)
        {
            Vector3 spawnPosition = Random.onUnitSphere * 1.5f + gameObject.transform.position;
            anomaly = Instantiate(anomalyPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Anomaly " + (currentAnomaly + 1) + " Spawned");
        }
    }
}

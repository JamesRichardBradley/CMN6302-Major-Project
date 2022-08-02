using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyGenerationScript : MonoBehaviour
{
    public GameObject anomalyPrefab, anomaly;
    private int anomaliesToGenerate;

    private void Start()
    {
        anomalyPrefab = (GameObject)Resources.Load("Anomaly");
        AnomalyGeneration();
    }

    void AnomalyGeneration()
    {
        anomaliesToGenerate = Random.Range(16, 24);

        for (int currentAnomaly = 0; currentAnomaly <= anomaliesToGenerate; currentAnomaly++)
        {
            Vector3 spawnPosition = Random.onUnitSphere * 1.025f + this.gameObject.transform.position;
            anomaly = Instantiate(anomalyPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Anomaly " + (currentAnomaly + 1) + " Spawned");
        }
    }
}

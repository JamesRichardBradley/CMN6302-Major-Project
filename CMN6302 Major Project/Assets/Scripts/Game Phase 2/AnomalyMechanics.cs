using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyMechanics : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // If Anomaly makes contact with the "Walk Player" increase the score by 1, then destroy this object.
        if (other.CompareTag("WalkPlayer"))
        {
            PlayerMovementScript player = other.GetComponentInParent<PlayerMovementScript>();
            player.score += 1;
            Destroy(this.gameObject);
        }
    }
}

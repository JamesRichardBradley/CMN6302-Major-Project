using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyMechanics : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WalkPlayer"))
        {
            PlayerMovementScript player = other.GetComponentInParent<PlayerMovementScript>();
            player.score += 1;
            Destroy(this.gameObject);
        }
    }
}

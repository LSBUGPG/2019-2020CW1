using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour{

    void OnTriggerEnter2D(Collider2D other)
    {
        ScoringSystem.theScore += 50;
        Destroy(gameObject);
    }
    
}

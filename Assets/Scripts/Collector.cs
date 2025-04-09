using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour, ICollectibles
{
    public void CheckIfCollectible(GameObject gameObject){    
        if(gameObject.tag == "collectible") {
            Debug.Log("Interface works!");
        }
    }
}

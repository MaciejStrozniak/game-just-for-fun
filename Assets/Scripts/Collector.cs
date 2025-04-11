using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour, ICollectibles
{
    // skrypt przyczepiany do obiektu capsuły

    public void CheckIfCollectible(GameObject gameObject){    
        if(gameObject.tag == "collectible") {
            Destroy(gameObject);
            Debug.Log("Interface works!");
        }
    }
}

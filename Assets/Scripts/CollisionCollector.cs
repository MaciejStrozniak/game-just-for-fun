using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCollector : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        ICollectibles collectibles = collision.gameObject.GetComponent<ICollectibles>();

        if(collectibles != null) {
            collectibles.CheckIfCollectible(collision.gameObject);
        }
        else
            Debug.Log("Nie działa");
    }
}

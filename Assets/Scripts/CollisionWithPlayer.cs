using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionWithPlayer : MonoBehaviour
{
    int countdownToExtinction = 0;
    bool destroyActive = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O) && destroyActive == false) {
            destroyActive = !destroyActive;
            Debug.Log(destroyActive);
        }
        else if(Input.GetKeyDown(KeyCode.O) && destroyActive == true)
            destroyActive = !destroyActive;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().color = UnityEngine.Random.ColorHSV();
            countdownToExtinction ++;
            if(countdownToExtinction == 3 && destroyActive == true)
                Destroy(gameObject);
        }
    }
}

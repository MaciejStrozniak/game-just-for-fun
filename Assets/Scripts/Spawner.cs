using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
// public GameObject player;
public GameObject follower;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(player, Vector3.zero, Quaternion.identity);
        // if(follower.tag == "Follower")
            Instantiate(follower, new Vector3(2f, 3f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
            Instantiate(follower, new Vector3(UnityEngine.Random.Range(-10,10), UnityEngine.Random.Range(-10,10), 0f), Quaternion.identity);

    }
}

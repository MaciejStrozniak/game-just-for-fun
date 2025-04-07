using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHealthSubscriber : MonoBehaviour
{    
    public string playerStatus = "";
    public int playerHealth = 100;

    void Awake()
    {
        playerStatus = "Alive";
        playerHealth = 100;
    }
    // Start is called before the first frame update
    void Start()
    {
        EventTest eventTest = GetComponent<EventTest>();
        eventTest.OnHealthChange += Subscriber_Dmg;
    }

    private void Subscriber_Dmg(object sender, EventTest.HealthChangeArg arg) {
        playerHealth -= playerHealth - 20;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            EventTest eventTest = GetComponent<EventTest>();

            // Subscriber_Dmg?.Invoke(this, e);
            Debug.Log(playerHealth);
        }
    }  
}

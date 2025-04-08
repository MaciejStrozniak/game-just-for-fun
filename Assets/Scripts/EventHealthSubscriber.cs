using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class EventHealthSubscriber : MonoBehaviour
{   
    HealthEvent healthEvent; 

    void Start()
    {
        healthEvent = GetComponent<HealthEvent>();
        // healthEvent.OnHealthChange += HandleHealthChange;
    }

    private void HandleHealthChange(object sender, HealthEvent.HealthChangeEventArg e) {
        // if(Input.GetKeyDown(KeyCode.R)){
        //     healthEvent.PhysicalDmg();
        //     Debug.Log("Physical damage delt!: " + e.PlayerHealth);
        // }

        // if(Input.GetKeyDown(KeyCode.T)) {
        //     healthEvent.FireDmg();
        //     Debug.Log("Fire damage delt!: " + e.PlayerHealth);
        // }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            healthEvent.PhysicalDmg(15);            
        }
        else if(Input.GetKeyDown(KeyCode.T)) {
            healthEvent.FireDmg(30);
        }
        else if(Input.GetKeyDown(KeyCode.Y)) {
            healthEvent.HealingFactor(30);
        }
    }
}

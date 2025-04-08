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

        healthEvent.OnPhysicalDmg += PhysicalDmg;
        healthEvent.OnPhysicalDmg += DebugPhysicalDmg;

        healthEvent.OnFireDmg += FireDmg;
        healthEvent.OnFireDmg += DebugFireDmg;

        healthEvent.OnHealing += Healing;
        healthEvent.OnHealing += DebugHealing;
    }

    private void PhysicalDmg(object sender, HealthEvent.HealthChangeEventArg e) {
       e.PlayerHealth -= 10;
    }

    private void FireDmg(object sender, HealthEvent.HealthChangeEventArg e) {
       e.PlayerHealth -= 20;
    }

    private void Healing(object sender, HealthEvent.HealthChangeEventArg e) {
       e.PlayerHealth = 100;
    }

    private void DebugPhysicalDmg(object sender, HealthEvent.HealthChangeEventArg e) {
       Debug.Log("Physical damage! " + e.PlayerHealth);
    }

    private void DebugFireDmg(object sender, HealthEvent.HealthChangeEventArg e) {
       Debug.Log("Fire damage! " + e.PlayerHealth);
    }

    private void DebugHealing(object sender, HealthEvent.HealthChangeEventArg e) {
       Debug.Log("Healing factor! " + e.PlayerHealth);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEvent : MonoBehaviour
{
    public event EventHandler<HealthChangeEventArg> OnHealthChange;
        public class HealthChangeEventArg : EventArgs {
            public int PlayerHealth = 100;
        }

    HealthChangeEventArg healthChangeEventArg = new HealthChangeEventArg();

    public void PhysicalDmg(int physicalDmg) {
        healthChangeEventArg.PlayerHealth -= physicalDmg;
        OnHealthChange?.Invoke(this, healthChangeEventArg);
        Debug.Log("Physical damage delt! " + healthChangeEventArg.PlayerHealth);
    }

    public void FireDmg(int fireDmg) {
        healthChangeEventArg.PlayerHealth -= fireDmg;
        OnHealthChange?.Invoke(this, healthChangeEventArg);
        Debug.Log("Fire damage delt! " + healthChangeEventArg.PlayerHealth);
    }

    public void HealingFactor(int healing) {
        healthChangeEventArg.PlayerHealth += healing;
        OnHealthChange?.Invoke(this, healthChangeEventArg);
        Debug.Log("HEALING FACTOR! Health: " + healthChangeEventArg.PlayerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

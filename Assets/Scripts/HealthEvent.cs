using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HealthEvent : MonoBehaviour
{
    public event EventHandler<HealthChangeEventArg> OnPhysicalDmg;
        public class HealthChangeEventArg : EventArgs {
            public int PlayerHealth = 100;
        }

    public event EventHandler<HealthChangeEventArg> OnFireDmg;
    public event EventHandler<HealthChangeEventArg> OnHealing;

    HealthChangeEventArg healthChangeEventArg = new HealthChangeEventArg();

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            OnPhysicalDmg?.Invoke(this, healthChangeEventArg);     
        }
        else if(Input.GetKeyDown(KeyCode.T)) {
            OnFireDmg?.Invoke(this, healthChangeEventArg);     
        }
        else if(Input.GetKeyDown(KeyCode.Y)) {
            OnHealing?.Invoke(this, healthChangeEventArg);     
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    public event EventHandler OnSpacePress;
    public event EventHandler<HealthChangeArg> OnHealthChange;

    public class HealthChangeArg : EventArgs {
        public int HealthChangeAmount {
            get;
            private set;
        }

        public HealthChangeArg(int healthChangeAmount) {
            HealthChangeAmount = healthChangeAmount;
        }
    } 
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            OnSpacePress?.Invoke(this, EventArgs.Empty);
        }
    }    
}
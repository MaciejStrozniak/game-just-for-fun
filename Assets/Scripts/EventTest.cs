using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    public event EventHandler OnSpacePress;
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            OnSpacePress?.Invoke(this, EventArgs.Empty);
        }
    }    
}
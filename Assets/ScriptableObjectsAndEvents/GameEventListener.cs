using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    // ScriptableObject to listen to
    public ScriptableObjectWIthEvents Event;

    // Response activated when ScriptableObject is raised/activated
    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);

    }

    private void OnDisable()
    {
        Event.UnRegisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}

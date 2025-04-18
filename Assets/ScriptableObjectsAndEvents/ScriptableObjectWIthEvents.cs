using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "ScriptableObjectWithEvents", menuName = "ScriptableObjectsAndEvents/TestForScriptableObject")]
[CreateAssetMenu]
public class ScriptableObjectWIthEvents : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnRegisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }

    public void Raise()
    {
        for(int i=listeners.Count-1; 1>=0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }
}

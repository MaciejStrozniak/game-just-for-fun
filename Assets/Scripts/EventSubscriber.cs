using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventTest eventTest = GetComponent<EventTest>();
        AudioSource audioSource = GetComponent<AudioSource>();
        eventTest.OnSpacePress += Testing_SubscriberEvent;
    }

    private void Testing_SubscriberEvent(object sender, EventArgs e) {
        
        AudioSource audioSource = GetComponent<AudioSource>();

        if(audioSource.isPlaying) {
            audioSource.Pause();
            Debug.Log("Subscriber - ambient pause!");
        }
        else {
            audioSource.Play();
            Debug.Log("Subscriber - ambient start!");
        }
    }    
}

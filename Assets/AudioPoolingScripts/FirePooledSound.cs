using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePooledSound : MonoBehaviour
{
    [SerializeField] private AudioClip soundToFire;
    [SerializeField] private float volume = 1f;
    [SerializeField] private float playInterval = 0.3f;

    private float nextPlayTime = 0;
    private bool isPlaying = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            isPlaying = !isPlaying;
        }

        if(isPlaying && Time.time >= nextPlayTime)
        {
            AudioPool.Instance.PlayOneShot(soundToFire, transform.position, volume);
            nextPlayTime = Time.time + playInterval;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PooledAudioSource : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioPool pool;
    private Coroutine returnToPoolCoroutine;

    public void Initialize(AudioPool audioPool)
    {
        pool = audioPool;
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void PlayOneShot(AudioClip audioClip, float volume = 1f)
    {
        if(returnToPoolCoroutine != null)
        {
            StopCoroutine(returnToPoolCoroutine);
        }

        audioSource.volume = volume;
        audioSource.PlayOneShot(audioClip);
        returnToPoolCoroutine = StartCoroutine(ReturnToPoolAfterDelay(audioClip.length));
    }

    public void Play(AudioClip audioClip, bool loop = false, float volume = 1f)
    {
        if(returnToPoolCoroutine != null)
        {
            StopCoroutine(returnToPoolCoroutine);
            returnToPoolCoroutine = null;
        }

        audioSource.clip = audioClip;
        audioSource.loop = loop;
        audioSource.volume = volume;
        audioSource.Play();

        if(!loop)
        {
            returnToPoolCoroutine = StartCoroutine(ReturnToPoolAfterDelay(audioClip.length));
        }
    }

    public void Stop()
    {
        if(returnToPoolCoroutine != null)
        {
            StopCoroutine(returnToPoolCoroutine);
            returnToPoolCoroutine = null;
        }

        audioSource.Stop();
        audioSource.clip = null;
        audioSource.loop = false;
    }

    private IEnumerator ReturnToPoolAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        pool.ReturnToPool(this);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void SetPitch(float pitch)
    {
        audioSource.pitch = pitch;
    }

    public void SetSpatialBlend(float blend)
    {
        audioSource.spatialBlend = blend;
    }

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }

    public void Pause()
    {
        audioSource.Pause();
    }

    public void UnPause()
    {
        audioSource.UnPause();
    }
}

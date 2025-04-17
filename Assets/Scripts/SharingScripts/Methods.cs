using UnityEngine;

public class Methods : MonoBehaviour
{
    public AudioSource _internalAudioSource;

    public AudioSource setAudioSource(AudioSource audioSource)
    {
        _internalAudioSource = audioSource;

        return _internalAudioSource;
    }

    public AudioClip setAudioClip(AudioClip audioClip)
    {
        AudioClip audioClipToSet = audioClip;

        return audioClipToSet;
    }

    public void startAudioSource(AudioClip audioClip)
    {
        _internalAudioSource.clip = audioClip;
        _internalAudioSource.Play();
    }

    public void changeVolumeFloat(float volume)
    {
        _internalAudioSource.volume = volume;
    }

    public void setMute(float volume)
    {
        _internalAudioSource.volume = volume;
    }

    public void stopAudioSource()
    {
        _internalAudioSource.Stop();
    }

}

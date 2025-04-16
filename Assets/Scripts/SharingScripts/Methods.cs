using UnityEngine;

public class Methods : MonoBehaviour
{
    public AudioClip setAudioClip(AudioClip getAudioClip)
    {
        AudioClip setAudioClip = getAudioClip;

        return setAudioClip;
    }

    public void startAudioSource(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public AudioSource setNewVolume(AudioSource audioSourceToSet, float volume)
    {
        audioSourceToSet.volume = volume;

        return audioSourceToSet;
    }

}

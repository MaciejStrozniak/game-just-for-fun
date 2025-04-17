using System.Collections;
using UnityEngine;

public class MethodsReader : MonoBehaviour
{
    [SerializeField] private Methods methods;
    [SerializeField] private AudioClip audioClipFromInspector;
    [SerializeField] private float volume = 10f;

    private float waitUntilTheTimeIsRight = 5f;
    private bool debugAudioMute = true;

    // Start is called before the first frame update
    void Start()
    {
        volume = 1f;
        methods.setAudioSource(gameObject.AddComponent<AudioSource>());
        methods.startAudioSource(methods.setAudioClip(audioClipFromInspector));    
    }

    // Update is called once per frame
    void Update()
    {
        waitUntilTheTimeIsRight -= Time.deltaTime;

        if(waitUntilTheTimeIsRight >= 0)
        {
            volume -= 0.0001f;
            methods.changeVolumeFloat(volume);
            Debug.Log(waitUntilTheTimeIsRight);
        }
        else if(waitUntilTheTimeIsRight <= 0 && debugAudioMute)
        {
            volume = 0;
            methods.setMute(volume);
            Debug.Log("Music mute!");
            debugAudioMute = !debugAudioMute;
            StartCoroutine(StopAudioSourceAfterSeconds(2f));
        }
    }

    private IEnumerator StopAudioSourceAfterSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        methods.stopAudioSource();
        Debug.Log(methods._internalAudioSource.isPlaying);
    }
}

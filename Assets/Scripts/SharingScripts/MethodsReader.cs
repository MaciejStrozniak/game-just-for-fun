using UnityEngine;

public class MethodsReader : MonoBehaviour
{
    public Methods methods;

    [SerializeField] private AudioClip audioClipFromInspector;
    [SerializeField] private AudioSource thisAudioSource;
    [SerializeField] private float volume = 0;

    private float waitUntilTheTimeIsRigth = 5f;
    private bool debugAudioMute = true;

    // Start is called before the first frame update
    void Start()
    {
        thisAudioSource = gameObject.AddComponent<AudioSource>();
        methods.startAudioSource(thisAudioSource, methods.setAudioClip(audioClipFromInspector));    
    }

    // Update is called once per frame
    void Update()
    {
        waitUntilTheTimeIsRigth -= Time.deltaTime;

        if(waitUntilTheTimeIsRigth >= 0)
            Debug.Log(waitUntilTheTimeIsRigth);


        else if(waitUntilTheTimeIsRigth <= 0 && debugAudioMute)
        {
            methods.setNewVolume(thisAudioSource, volume);
            Debug.Log("Music mute!");
            debugAudioMute = !debugAudioMute;
        }
    }
}

using UnityEngine;

public class PlayAmbOnAwake : MonoBehaviour
{
    [SerializeField] AudioClip ambToPlayOnAwake;
    [SerializeField] private float volume = 1f;
    [SerializeField] private float playInterval = 0.3f;
    [SerializeField] private bool isLooping = true;

    private PooledAudioSource ambSource;

    // Start is called before the first frame update
    void Start()
    {
        ambSource = AudioPool.Instance.PlayWithRandomPitch(ambToPlayOnAwake, transform.position, isLooping, volume);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(ambSource != null)
            {
                AudioPool.Instance.ReturnToPool(ambSource);
                ambSource = null;
            }
            else
                ambSource = AudioPool.Instance.PlayWithRandomPitch(ambToPlayOnAwake, transform.position, isLooping, volume);
        }
    }
}

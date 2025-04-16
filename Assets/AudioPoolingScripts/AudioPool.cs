using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class AudioPool : MonoBehaviour
{
    private static AudioPool instance;
    public static AudioPool Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject gameObject = new GameObject("Audio Pool");
                instance = gameObject.AddComponent<AudioPool>();
                DontDestroyOnLoad(gameObject);
            }
    
            return instance;
        }
    }

    [System.Serializable]
    public class PoolSettings
    {
        public int initialSize = 10;
        public int maxSize = 20;
        public bool expandable = true;
    }

    public PoolSettings settings = new PoolSettings();

    private Queue<PooledAudioSource> availableAudioSource = new Queue<PooledAudioSource>();
    private List<PooledAudioSource> activeAudioSources = new List<PooledAudioSource>();

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        InitializePool();
    }

    // lokalizacja Unity localization package
    // Unity postprocess
    
    private void InitializePool()
    {
        Profiler.BeginSample("AudioPool Initialization");

        for(int i =0 ; i < settings.initialSize; i++)
        {            
            CreateNewAudioSource();
        }

        Profiler.EndSample();
    }

    private PooledAudioSource CreateNewAudioSource()
    {
        GameObject audioObject = new GameObject("PooledAudio");
        audioObject.transform.SetParent(transform);
        PooledAudioSource pooledSource = audioObject.AddComponent<PooledAudioSource>();
        pooledSource.Initialize(this);
        availableAudioSource.Enqueue(pooledSource);
        return pooledSource;
    }

    public PooledAudioSource GetAudioSource()
    {
        if(availableAudioSource.Count == 0)
        {
            if(settings.expandable && (activeAudioSources.Count + availableAudioSource.Count) < settings.maxSize)
            {
                CreateNewAudioSource();
            }
            else
            {
                Debug.Log("Max capacity reached!");

                return null;
            }
        }

        PooledAudioSource source = availableAudioSource.Dequeue();
        activeAudioSources.Add(source);
        source.gameObject.SetActive(true);
        return source;
    }

    public void ReturnToPool(PooledAudioSource source)
    {
        if(activeAudioSources.Contains(source))
        {
            source.SetPitch(1f);
            source.Stop();
            source.gameObject.SetActive(false);
            activeAudioSources.Remove(source);
            availableAudioSource.Enqueue(source);
        }
    }

    public void PlayOneShot(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        PooledAudioSource source = GetAudioSource();
        if(source != null)
        {
            source.transform.position = position;
            source.PlayOneShot(audioClip, volume);
        }
    }

    public PooledAudioSource Play(AudioClip audioClip, Vector3 position, bool loop = false, float volume = 1f)
    {
        PooledAudioSource source = GetAudioSource();
        if(source != null)
        {
            source.transform.position = position;
            source.Play(audioClip, loop, volume);
        }

        return source;
    }

    public PooledAudioSource PlayWithRandomPitch(AudioClip audioClip, Vector3 position, bool loop = false, float volume = 1f)
    {
        PooledAudioSource source = GetAudioSource();
        if(source != null)
        {
            source.transform.position = position;
            source.SetPitch(UnityEngine.Random.Range(0f, 2f));
            source.Play(audioClip, loop, volume);
        }

        return source;
    }

}

// using UnityEngine;
// using System.Collections.Generic;

// public class AudioPool : MonoBehaviour
// {
//     private static AudioPool instance;
//     public static AudioPool Instance
//     {
//         get
//         {
//             if (instance == null)
//             {
//                 GameObject go = new GameObject("AudioPool");
//                 instance = go.AddComponent<AudioPool>();
//                 DontDestroyOnLoad(go);
//             }
//             return instance;
//         }
//     }

//     [System.Serializable]
//     public class PoolSettings
//     {
//         public int initialSize = 10;
//         public int maxSize = 20;
//         public bool expandable = true;
//     }

//     public PoolSettings settings = new PoolSettings();
    
//     private Queue<PooledAudioSource> availableAudioSources = new Queue<PooledAudioSource>();
//     private List<PooledAudioSource> activeAudioSources = new List<PooledAudioSource>();

//     private void Awake()
//     {
//         if (instance != null && instance != this)
//         {
//             Destroy(gameObject);
//             return;
//         }

//         instance = this;
//         InitializePool();
//     }

//     private void InitializePool()
//     {
//         for (int i = 0; i < settings.initialSize; i++)
//         {
//             CreateNewAudioSource();
//         }
//     }

//     private PooledAudioSource CreateNewAudioSource()
//     {
//         GameObject audioObj = new GameObject("PooledAudio");
//         audioObj.transform.SetParent(transform);
//         PooledAudioSource pooledSource = audioObj.AddComponent<PooledAudioSource>();
//         pooledSource.Initialize(this);
//         availableAudioSources.Enqueue(pooledSource);
//         return pooledSource;
//     }

//     public PooledAudioSource GetAudioSource()
//     {
//         if (availableAudioSources.Count == 0)
//         {
//             if (settings.expandable && (activeAudioSources.Count + availableAudioSources.Count) < settings.maxSize)
//             {
//                 CreateNewAudioSource();
//             }
//             else
//             {
//                 Debug.LogWarning("Audio pool capacity reached! Consider increasing pool size.");
//                 return null;
//             }
//         }

//         PooledAudioSource source = availableAudioSources.Dequeue();
//         activeAudioSources.Add(source);
//         source.gameObject.SetActive(true);
//         return source;
//     }

//     public void ReturnToPool(PooledAudioSource source)
//     {
//         if (activeAudioSources.Contains(source))
//         {
//             source.Stop();
//             source.gameObject.SetActive(false);
//             activeAudioSources.Remove(source);
//             availableAudioSources.Enqueue(source);
//         }
//     }

//     public void PlayOneShot(AudioClip clip, Vector3 position, float volume = 1f)
//     {
//         PooledAudioSource source = GetAudioSource();
//         if (source != null)
//         {
//             source.transform.position = position;
//             source.PlayOneShot(clip, volume);
//         }
//     }

//     public PooledAudioSource Play(AudioClip clip, Vector3 position, bool loop = false, float volume = 1f)
//     {
//         PooledAudioSource source = GetAudioSource();
//         if (source != null)
//         {
//             source.transform.position = position;
//             source.Play(clip, loop, volume);
//             return source;
//         }
//         return null;
//     }
// } 
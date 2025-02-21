using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool isCausingDamage = false;
    public int numberOfPickups = 0;

    public TextAsset saveFile;

    [System.Serializable]
    public class SaveData
    {
        public string pickUps;
    }

    [System.Serializable]
    public class DataList
    {
        public SaveData[] datas;
    }

    public SaveData[] datasToStore;

    void Start()
    {
        // DataList dataList = JsonUtility.FromJson<DataList>();
    }

}



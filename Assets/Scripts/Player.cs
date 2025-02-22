using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Hardware;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool isCausingDamage = false;
    public int numberOfPickups = 0;
    public string path = "";

    [Serializable]
    public class SaveClass
    {
        public int pickups;
        public string level = "First level";
    }

    void Start()
    {

        string directory = Directory.GetParent(Application.dataPath).FullName + "/Saves/";
        Directory.CreateDirectory(directory);
        path = directory + "savedGames.json";

        // load json file
        LoadGame();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
            SaveGame();

        if(Input.GetKeyDown(KeyCode.L))
            ResetPoints();
    }


    private void LoadGame()
    {
        string loadedJSON = File.ReadAllText(path);
        SaveClass loadedData = JsonUtility.FromJson<SaveClass>(loadedJSON);
        numberOfPickups = loadedData.pickups;
        Debug.Log("Game loaded from: " + path);
        Debug.Log("Number of pickups: " + numberOfPickups);

    }
    public void SaveGame()
    {
        SaveClass mySaveFile = new SaveClass();
        mySaveFile.pickups = numberOfPickups; // here I need to change numberOfPickups to SaveClass.pickups value from loaded json file
        string json = JsonUtility.ToJson(mySaveFile);
        File.WriteAllText(path, json);
        Debug.Log("Game saved to: " + path);
    }

    public void ResetPoints()
    {
        numberOfPickups = 0;
        SaveGame();
        Debug.Log(numberOfPickups);
    }
    
}



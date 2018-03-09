using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class dataManagement : MonoBehaviour
{

    public static dataManagement datamanagement;
    public int score;

    private void Awake()
    {
        if (datamanagement == null)
        {
            DontDestroyOnLoad(gameObject);
            datamanagement = this;
        }
        else if (datamanagement != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData () {
        //Data is saved
        BinaryFormatter BinForm = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
        gameData data = new gameData();
        data.score = score;
        BinForm.Serialize(file, data);
        file.Close();

    }

    public void LoadData () {
        //Data is loaded
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat")) {
            BinaryFormatter BinForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)BinForm.Deserialize(file);
            file.Close();
            score = data.score;
        }
    }
}


[Serializable]
class gameData {
    public int score;

}
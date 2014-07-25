using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {
    //public static GameControl control;
	
	void Start () {
	
	}
	
	
	void Update () {
	
	}
    /*
    public void Exist() 
    {
        if (!File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            Save();
        }
    }
    
    public void Save() 
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.monedas += Cerebro.MONEDASTOTALES;
        data.cristales += Cerebro.CRISTALESTOTALES;
        if (data.bestScore < Cerebro.BESTSCORE)
            data.bestScore = Cerebro.BESTSCORE;
        data.metrosTotales += Cerebro.METROSTOTALES;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load() 
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) 
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            Cerebro.MONEDASTOTALES = data.monedas;
            Cerebro.CRISTALESTOTALES = data.cristales;
            Cerebro.BESTSCORE = data.bestScore;
            Cerebro.METROSTOTALES = data.metrosTotales;
        }   
    }
    */
}
/*
[Serializable]
class PlayerData
{
    public int monedas;
    public int cristales;
    public int bestScore;
    public int metrosTotales;
}*/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public DataHolder dataHolder;

    public void Awake()
    {
            //Loads all saved data when entering playmode
        dataHolder = Load();
    }

    public DataHolder Load()
    {   
                //called when playmode is entered loading all saved data in the game.
        var serializer = new XmlSerializer(typeof(DataHolder));
        using (var stream = new FileStream(Application.dataPath + "/InventorySystemSave.xml", FileMode.Open))
        {
            return serializer.Deserialize(stream) as DataHolder;
        }
    }

    public void OnApplicationQuit()
    {
        //seralizes all data in DataHolder when player exits playmode
        var serializer = new XmlSerializer(typeof(DataHolder));
        using (var stream = new FileStream(Application.dataPath + "/InventorySystemSave.xml", FileMode.Create))
        {
            serializer.Serialize(stream, dataHolder);
        }
    }
}
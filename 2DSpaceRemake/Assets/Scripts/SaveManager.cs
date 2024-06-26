using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{

    public static SaveManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            Load();
        }
    }

    private SaveClass saveInfo;
    public void Save()
    {
        string serializedobject = Serialize(saveInfo);
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey("saveFile"))
        {
            // load deserialize
            saveInfo = Deserialize(PlayerPrefs.GetString("saveFile"));
        }
        else
        {
            // create a file and save
            Debug.Log("Creating new file");
            saveInfo = new SaveClass();
            Save();
        }
    }
    private string Serialize(SaveClass toBeSerialized)
    {
        XmlSerializer xml = new XmlSerializer(typeof(SaveClass));
        StringWriter writer = new StringWriter();
        xml.Serialize(writer, toBeSerialized);
        return writer.ToString();
    }
    private SaveClass Deserialize(string XmlSerialized)
    {
        XmlSerializer xml = new XmlSerializer(typeof(SaveClass));
        StreamReader reader = new StreamReader(XmlSerialized);
        return xml.Deserialize(reader) as SaveClass;
    }
}

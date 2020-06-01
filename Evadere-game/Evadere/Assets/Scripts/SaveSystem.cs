using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
    public static void SavePlayer(PlayerData playerData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        try
        {
            formatter.Serialize(stream, playerData);
        }
        finally
        {
            stream.Close();
        }
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/save.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            try
            {
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                return data;
            }
            finally
            {
                stream.Close();               
            }     
        } else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem
{
    public static void SaveGame(God god)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(god);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/game.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = (GameData) formatter.Deserialize(stream);
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("File not found in " + path);
            return new GameData();
        }
    }

}

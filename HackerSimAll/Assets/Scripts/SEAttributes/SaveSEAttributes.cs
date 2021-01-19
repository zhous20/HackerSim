using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSEAttributes : MonoBehaviour
{
    public static void SavePlayer (SEAttributes player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/SEAttributes.a";
        FileStream stream = new FileStream(path, FileMode.Create);

        SEAttributes savePlayer = player;

        formatter.Serialize(stream, savePlayer);
        //Debug.Log("Saved file to: " + path);
        stream.Close();
    }

    public static SEAttributes LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/SEAttributes.a";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SEAttributes playerLoad = formatter.Deserialize(stream) as SEAttributes;
            stream.Close();
            return playerLoad;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public static class SaveParameters
{
    public static void saveCurrentParameters(UIElementsEditorWindow currentParameters, string name)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = "Assets/ArchitektonBuilder/SavedParameters/" + name + ".architektonParameters";

        FileStream stream = new FileStream(path, FileMode.Create);

        ArchitektonBuilderParameter parameters = new ArchitektonBuilderParameter(currentParameters);

        formatter.Serialize(stream, parameters);
        stream.Close();
    }

    public static ArchitektonBuilderParameter loadParameters(string name)
    {
        //string path = "Assets/SavedParameters/" + name + ".architektonParameters";

        if(File.Exists(name))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(name, FileMode.Open);

            ArchitektonBuilderParameter loadedData = formatter.Deserialize(stream) as ArchitektonBuilderParameter;
            stream.Close();

            return loadedData;
        }
        else
        {
            Debug.LogError("Couldnt fine file at " + name);
            return null;
        }
    }
}

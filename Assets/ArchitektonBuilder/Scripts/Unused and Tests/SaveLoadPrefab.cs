// This script creates a new menu item Examples>Create Prefab in the main menu.
// Use it to create Prefab(s) from the selected GameObject(s).
// Prefab(s) are placed in the "Prefabs" folder.
using System.IO;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class SaveLoadPrefab : MonoBehaviour
{
    // Creates a new menu item 'Examples > Create Prefab' in the main menu.
	//[MenuItem("Examples/Create Prefab")]
	public static void SavePrefab()
	{
        GameObject[] objectArray = Selection.gameObjects;

        // Loop through every GameObject in the array above
        foreach (GameObject instance in objectArray)
        {
			// Create folder Prefabs and set the path as within the Prefabs folder,
			// and name it as the GameObject's name with the .Prefab format
			if (!Directory.Exists("Assets/Prefabs"))
                    AssetDatabase.CreateFolder("Assets", "Prefabs");
                string localPath = "Assets/Prefabs/" + instance.name + ".prefab";

			// Make sure the file name is unique, in case an existing Prefab has the same name.
			localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
            
            if(instance.GetComponent<MeshFilter>() != null)
            {
                Mesh refMesh = instance.GetComponent<MeshFilter>().mesh;

                AssetDatabase.CreateAsset(refMesh, "Assets/Prefabs/" + instance.name + ".assets");
                AssetDatabase.SaveAssets();
            }
			// Create the new Prefab and log whether Prefab was saved successfully.
			bool prefabSuccess;
		    PrefabUtility.SaveAsPrefabAssetAndConnect(instance, localPath, InteractionMode.UserAction, out prefabSuccess);
            if (prefabSuccess == true)
			{
				Debug.Log("Prefab was saved successfully");
			}
			else
                    Debug.Log("Prefab failed to save" + prefabSuccess);
            }
            

            
        }

        // Creates a new menu item 'Examples > Load Prefab' in the main menu.
        //[MenuItem("Examples/Load Prefab")]
        public static void LoadPrefab()
		{
            // Keep track of the currently selected GameObject(s)
            GameObject[] objectArray = Selection.gameObjects;
            Material mat = new Material(Shader.Find("Standard"));

            foreach (GameObject gameObject in objectArray)
            {
                // Instantiate at position (0, 0, 0) and zero rotation.
                Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity);

                foreach (Transform child in gameObject.transform)
                {
                    // Adds a standard material to the object
                    child.GetComponent<MeshRenderer>().material = mat;

                    // Operation to add MeshFilter needed here so it's not just a wireframe
                }
		    }
		}
        
        /*
        // Disable the menu item if no selection is in place.
        [MenuItem("Examples/Create Prefab", true)]
        static bool ValidateCreatePrefab()
        {
            return Selection.activeGameObject != null && !EditorUtility.IsPersistent(Selection.activeGameObject);
        }
        */
}

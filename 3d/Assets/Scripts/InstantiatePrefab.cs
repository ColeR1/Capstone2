using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{ public GameObject prefabToInstantiate; // Drag your prefab into this field in the Inspector.
    public NPC[] npclist;

    void Start()
    {
        for (int i = 0; i < npclist.Length; i++)
        {
            Vector3 spawnPosition = new Vector3(i * 2, 1, 0); // Adjust the spawn positions as needed.
            GameObject questGiver = Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);

            // Access the NPC data from the Scriptable Object for the instantiated GameObject.
            NPC npcData = npclist[i];
            
            // Now, you can access the NPC data for the instantiated GameObject.
            // For example, you can access the 'names' and 'dialouge' fields.
            string npcName = npcData.names;
            string[] npcDialogue = npcData.dialouge;

            // You can do something with this data for each instantiated GameObject.
            // For example, you might want to set the name and dialogue for the NPC in the instantiated prefab.
            // You'd need to have appropriate components in your prefab to display this information.
        }
    }
}

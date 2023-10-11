using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(fileName = "NPC file", menuName = "NPC Files Archive" )]
public class NPC : ScriptableObject
{
    public string names;
    [TextArea(1,15)]
    public string[] dialouge;
    [TextArea(1,15)]
    public string[] playerDialouge;

    public string[] GetPlayerDialog(){
        return playerDialouge;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class DialougeManager : MonoBehaviour
{
     public NPC npc;
     string []playerText;

    public bool isTalking = false;

    bool inTrigger = false;
    float distance;
    float curResponseTracker =0;

    public GameObject player;
    public GameObject dialougeUI;

    public TMP_Text npcName;
    public TMP_Text npcDialougeBox;
    public TMP_Text playerResponse;

    private void Start() {
        dialougeUI.SetActive(false);
    }

    private void Update()
    {
            if(Input.GetAxis("Mouse ScrollWheel") <0f)
            {
                curResponseTracker++;
                if(curResponseTracker >= npc.playerDialouge.Length -1)
                {
                    curResponseTracker = npc.playerDialouge.Length -1;
                }
            }
            else if(Input.GetAxis("Mouse ScrollWheel") >0f)
            {
                curResponseTracker--;
                if(curResponseTracker <0)
                {
                    curResponseTracker =0;
                }
            }
            //Trigger Dialouge
            Debug.Log("Press F to start Conversation");
            //trigger dialouge
            if(Input.GetKeyDown(KeyCode.F) && isTalking ==false && inTrigger ==true)
            {
                Debug.Log("Talking to" + gameObject);
                StartConversation();
            }
            else if(Input.GetKeyDown(KeyCode.F) && isTalking == true)
            {
                EndDialouge();
            }

            if(curResponseTracker == 0 && npc.playerDialouge.Length >=0)
            {
                playerResponse.text = playerText[0]; //npc.playerDialouge[0];
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialougeBox.text = npc.dialouge[1];
                }
            }
            else if(curResponseTracker == 1 && npc.playerDialouge.Length >=1)
            {
                playerResponse.text = playerText[1];//npc.playerDialouge[1];
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialougeBox.text = npc.dialouge[2];
                }
            }
            else if(curResponseTracker == 2 && npc.playerDialouge.Length >=2)
            {
                playerResponse.text = playerText[2];//npc.playerDialouge[2];
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialougeBox.text = npc.dialouge[3];
                }
            }
        }

   private void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag== "Player")
    {
        inTrigger = true;
    }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag=="Player")
        {
            inTrigger = false;
            dialougeUI.SetActive(false);
        }
    }


    private void EndDialouge()
    {
        isTalking = false;
        dialougeUI.SetActive(false);
    }

    private void StartConversation()
    {
        isTalking = true;
        curResponseTracker = 0;
        dialougeUI.SetActive(true);
        npcName.text = npc.name;
        npcDialougeBox.text = npc.dialouge[0];
        playerText = npc.GetPlayerDialog();
    }
}

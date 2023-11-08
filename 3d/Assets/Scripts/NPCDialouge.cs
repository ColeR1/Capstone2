using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;

[System.Serializable]
public class Dialogue
{
    [TextArea(3, 10)]
    public string[] lines;
}


public class NPCDialouge : MonoBehaviour
{
    public string NPCN;
    public TMP_Text NPCNAme;
    public GameObject dialogueUI;
    public TMP_Text dialogueText;

    public Dialogue dialogueData;

    private bool inTriggerZone = false;
    private bool dialogueActive = false;
    private int currentLine = 0;

    private bool Talking;
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTriggerZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTriggerZone = false;
            dialogueActive = false;
            dialogueUI.SetActive(false);
        }
    }

    void Update()
    {
        if (inTriggerZone && !dialogueActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue();
            }
        }

        if (dialogueActive)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                ContinueDialogue();
                
            }
        }
    }

    void StartDialogue()
    {
        Talking = true;
        dialogueActive = true;
        dialogueUI.SetActive(true);

        if (dialogueData != null && dialogueData.lines.Length > 0)
        {
            NPCNAme.SetText($"{NPCN}");
            currentLine = 0;
            dialogueText.text = dialogueData.lines[currentLine];
        }
        else
        {
            EndDialogue();
        }
    }

    void ContinueDialogue()
    {
        if (currentLine < dialogueData.lines.Length - 1)
        {
            currentLine++;
            dialogueText.text = dialogueData.lines[currentLine];
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueActive = false;
        dialogueUI.SetActive(false);
        Talking = false;
    }
}
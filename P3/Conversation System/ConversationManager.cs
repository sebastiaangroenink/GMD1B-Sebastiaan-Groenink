using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ConversationManager : MonoBehaviour {
    public Dialogues dialogue;
    public GameObject dialogueWindow;
    public GameObject yesReply;
    public GameObject noReply;
    public GameObject npcInteract;
    public bool inConversation;
    public Text conversationText;
    public RaycastHit interact;
    public PlayerController pController;
    public PickupManager pickManager;

	void Start () {
        dialogueWindow.SetActive(false);
	}
	
	
	void Update () {
        Conversation();
        CheckForConversation();
        Interact();
        CheckForEnd();
	}

    void Conversation() 
    {
        if (npcInteract != null) {
            conversationText.text = npcInteract.GetComponent<Dialogues>().dialogueList[dialogue.currDial];

            if (dialogue.questionList[dialogue.currDial] != null)
            {
                yesReply.SetActive(true);
                noReply.SetActive(true);
            }
            else {
                yesReply.SetActive(false);
                noReply.SetActive(false);
                }

        }

    }

    void CheckForEnd()
    {
        if(dialogue != null) {
            if (dialogue.currDial >= dialogue.dialogueList.Capacity - 1)
            {
                dialogue.currDial = 0;
                yesReply.SetActive(false);
                noReply.SetActive(false);
                dialogueWindow.SetActive(false);
                pController.canMove = true;
                inConversation = false;
                npcInteract = null;
                conversationText.text = null;
            }
        }
    }

    void CheckForConversation()//checks if player is talking. If so, sets the conversation window active.
    {
        if (inConversation)
        {
            dialogueWindow.SetActive(true);
        }
        else
        {
            dialogueWindow.SetActive(false);
        }
    }

    void Interact()
    {
        if (Input.GetButtonDown("F"))
        {
           // Debug.DrawRay(pickManager.cam.transform.position, pickManager.cam.transform.forward * pickManager.rayRange, Color.red);
            if (Physics.Raycast(pickManager.cam.transform.position, pickManager.cam.transform.forward * pickManager.rayRange, out interact,pickManager.rayRange))
            {
                if (interact.transform.tag == "NPC")
                {
                    pController.canMove = false;
                    inConversation = true;
                    npcInteract = interact.transform.gameObject;
                }
            }
        }
    }

  public void ReplyButton()
    {
        dialogue.Chat();
    }
}

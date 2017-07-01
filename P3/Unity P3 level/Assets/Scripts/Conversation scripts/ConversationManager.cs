using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ConversationManager : MonoBehaviour {
    public Dialogues dialogue;
    public GameObject dialogueWindow;
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
	}

    void Conversation() //todo manage conversation 4Head
    {
        if (npcInteract != null) {
            conversationText.text = npcInteract.GetComponent<Dialogues>().dialogueList[dialogue.currDial];
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
            Debug.DrawRay(pickManager.cam.transform.position, pickManager.cam.transform.forward * pickManager.rayRange, Color.red);
            if (Physics.Raycast(pickManager.cam.transform.position, pickManager.cam.transform.forward * pickManager.rayRange, out interact, pickManager.rayRange))
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

//todo: request dialogue from correct NPC and get information about when to respond positive/negative etc etc.
//todo: Enable/disable buttons at correct dialogue moment,provided by dialogues script.

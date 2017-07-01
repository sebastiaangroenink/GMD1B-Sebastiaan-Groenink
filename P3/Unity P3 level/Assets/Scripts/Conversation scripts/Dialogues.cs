using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogues : MonoBehaviour {
    public List<string> dialogueList = new List<string>();
    public int currDial;
    public int addPos = 2;
    public int addNeg = 1;
    public bool firstReply;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
    void FirstReply()//sets addPos and addNeg correctly in case a player is asked someting on an odd index instead of an even index meaning you won't get a negative reply if you reply positive.
    {
       
    }


    public void Chat()  //asked when yes/no button is pressed.
    {
        if (firstReply && currDial % 2 == 0) // done first time replying to set addPos and NegPos correctly in case a player has to answer a question at an odd index instead of an even index.
        {
            addPos = 2;
            addNeg = 1;
            firstReply = false;
            Chat();
        }
        else if(firstReply && currDial %2 !=0)
        {
            addPos = 1;
            addNeg = 2;
            firstReply = false;
            Chat();
        }
        else if (!firstReply) { 

        if (currDial%2 == 0)
        {
            //is even. Negative response
            currDial += addNeg;
        }
            if (currDial % 2 != 0)
            {
                //is odd. Positive response
                currDial += addPos;
            }
             
        }
    }
}
//todo : Setup variables correctly so dialogue can be filled in in unity. And provide information as for when to give positive/negative response.
//todo : Give information to convoManager as for when to enable/disable Response buttons.

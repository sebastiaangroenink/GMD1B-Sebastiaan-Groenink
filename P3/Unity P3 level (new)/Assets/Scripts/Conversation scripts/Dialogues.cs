using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogues : MonoBehaviour {
    public List<string> dialogueList = new List<string>();
    public List<string> questionList = new List<string>();
    public int currDial;
    public int addPos;
    public int addNeg;
    public bool firstReply;
  

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
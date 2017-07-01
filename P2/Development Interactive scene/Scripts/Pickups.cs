using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {
    //pickup-type references
    public bool consumable;
    public bool interactible;
    public bool questItem;

    //player-type reference
    public GameObject player;
    
    //class references
    public PlayerController playerController;
    public PickupManager    pickManager;

    //particle references
    public GameObject positiveParticle;
    public GameObject negativeParticle;

	void Update () {
        ItemCheck();
        
	}

    void ItemCheck()//checks for active bools , if one is active then gets the transform from ''hit'' in pickManager and sends that information to the function ''consumable''
    {
        if (consumable)
        {
            Consumable(pickManager.hit.transform);
            consumable = false;
        }
    }
    void Consumable (Transform consumable)//if called , checks if the consumable item is positive or negative.
    {
            var potion = consumable.GetComponent<Potion>();//creates local variable to acces the Potion component of potions player interacts with.
        if (consumable.tag == "consumable")
        {
            if (consumable.GetComponent<Potion>().positive)
            {
                playerController.currHP += potion.modifyHP;
                playerController.currMP += potion.modifyMP;
                GameObject particlePositive = (GameObject)Instantiate(positiveParticle, playerController.transform.position, playerController.transform.rotation);
                particlePositive.transform.SetParent(player.transform);
                //if the consumable is positive, add a set amount of MP/HP and spawn particle effect which follows the player for a set amount of time.

            }
            else if (consumable.GetComponent<Potion>().negative)
            {
                playerController.currHP -= potion.modifyHP;
                playerController.currMP -= potion.modifyMP;
                GameObject particleNegative = (GameObject)Instantiate(negativeParticle, playerController.transform.position, playerController.transform.rotation);
                particleNegative.transform.SetParent(player.transform);
                //if negative consumable, remove set amount of HP/MP and spawn a different particle effect showing the player he consumed something bad for a set amount of time.

            }
        }
        if(consumable.tag == "Food")//if the provided transform has the tag ''food'' add a set amount of HP.
        {
            playerController.currHP += consumable.GetComponent<Food>().addHP;
        }
        Destroy(consumable.transform.gameObject);
        // destroys the consumable so you can't consume it over and over again.
    }
}

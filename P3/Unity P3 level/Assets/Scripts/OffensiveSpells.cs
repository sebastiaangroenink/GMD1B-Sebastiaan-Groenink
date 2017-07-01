using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveSpells : MonoBehaviour {
    //class references
    public PlayerController playerController;
    public SpellStats       spellStats;

    //spell references
    public GameObject       offensiveSpellOne;
    public int              selectedSpell;
    public List<GameObject> spells = new List<GameObject>();

    //spawn point reference
    public GameObject spellSpawn;

    //spell stat references
    public float firePower;
    public float shootCooldown;
    public float fireRate;


    void Update() {
        if (Input.GetButtonDown("Fire3"))
        {
            FireSpell();
        }
        SelectSpell();
    }

    void SelectSpell()//allows player to select spells with Q-E buttons.
    {
        spellStats = spells[selectedSpell].GetComponent<SpellStats>();//sets spellStats to the currently selected spell so the stats of the spell (like cooldown/MP cost etc) are set correctly.
        playerController.spellStats = spells[selectedSpell].GetComponent<SpellStats>();//sets the spellStats in the playerController correctly aswell.
        
        if (Input.GetButtonDown("Q") && selectedSpell >0)
        {
            selectedSpell -= 1;
        }
        if (Input.GetButtonDown("E") && selectedSpell < spells.Count -1)
        {
            selectedSpell += 1;
        }
    }

    void FireSpell()//shoots the selected spell. (in this project I only have shootable spells so Every spell can have a fixed amount of power added to them)
    {   
        if (Time.time > shootCooldown && playerController.currHP > spellStats.mpCost)
        {
            fireRate = spellStats.cooldown;//sets new fireRate after selected spell was fired.
            shootCooldown = Time.time + fireRate;//sets the new cooldown after spell was fired.
            GameObject currSpell = (GameObject)Instantiate(spells[selectedSpell], spellSpawn.transform.position, spellSpawn.transform.rotation);//instantiates a new gameObject which is the ''spell''
            currSpell.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * firePower);//adds set amount of force to the new item causing it to fly forward
            playerController.currMP -= spellStats.mpCost;//reduces players amount of MP according to spells set cost.
              
        }
    }
}

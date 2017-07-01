using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{

    //class references
    public Pickups pickups;
    public PlayerController playerController;

    //gameobject references
    public GameObject cam;

    //raycast references
    public int rayRange = 10;
    public RaycastHit hit;


    void Start()
    {

    }


    void Update()
    {
        RayCasting();
    }

    void RayCasting()//if player presses a certain button a raycast is fired at a set direction (front of player).
    {
        if (Input.GetButtonDown("F"))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward * rayRange, Color.red);
            if (Physics.Raycast(cam.transform.position, cam.transform.forward * rayRange, out hit, rayRange))
            {
                if (hit.transform.tag == "consumable")//if hitted object has consumable tag set "consumable" in pickups true which calls a new function.
                {
                    pickups.consumable = true;
                    
                }
                if (hit.transform.tag == "interactible")//if hitted object has interactible tag set "nteractible" in pickups true.
                {
                    pickups.interactible = true;
                }
                if (hit.transform.tag == "questItem")//if hitted object has questItem tag set "questItem" in pickups true.
                {
                    pickups.questItem = true;
                    Destroy(hit.transform.gameObject);//destroy hitted object because questItems are one time use items, while consumable could be used multiple times before destroyed.
                }
            }
        }
    }
}

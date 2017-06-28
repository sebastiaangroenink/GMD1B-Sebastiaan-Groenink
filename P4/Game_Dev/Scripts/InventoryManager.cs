using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //UI References
    public List<GameObject> invSlots = new List<GameObject>();
    public InventorySlot invSlot;
    public GameObject invUI;

    //inventory references
    public Transform currItem;
    public bool dragging;

    void Start()
    {
        invUI.gameObject.SetActive(false);
    }
    void Update()
    {
 
        Inventory();
        if (currItem != null)
        {
            if (dragging)   //if player holds an item, puts blocksRayCast to false so that the item won't block the raycasts whichw ould prevent the player from putting item in itemslots.
            {
                currItem.transform.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
            else if (!dragging)
            {
                currItem.transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
        }
    }

    void Inventory()
    {   
            //allows player to acces inventory menu.
        if (Input.GetButtonDown("OpenInv") && !dragging) //doesn't allow player to close menu when dragging around an item
        {
            if (invUI.activeInHierarchy == false )
            {
                invUI.gameObject.SetActive(true);
            }
            else if(invUI.activeInHierarchy == true)
            {
                invUI.gameObject.SetActive(false);
            }
        }
    }
}

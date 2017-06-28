using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot : MonoBehaviour {

    public InventoryManager invManager;
    public bool filled;
    public Transform inventory;
    public GameObject rayBlock;
	void Start () {
        
	}
	
	void Update () {
        if (invManager.currItem != null)
        {
            invManager.currItem.position = Input.mousePosition;
        }
        if (transform.childCount > 0)
        {
            filled = true;
        }
    }

    public void OnClicker(Transform t)
    {
        if (t.childCount == 1 && !invManager.dragging)
        {
            invManager.currItem = t.GetChild(0);
            t.GetChild(0).SetParent(inventory);
            invManager.dragging = true;
            filled = false;
        }
        else if (!filled &&invManager.currItem != null)
        {
                invManager.currItem.position = (t.position);
                invManager.currItem.SetParent(t);
                invManager.currItem = null;
                filled = true;
                invManager.dragging = false;  
        }
        else if(filled)
        {
            invManager.currItem.position = t.position;
            invManager.currItem.SetParent(t);
            invManager.currItem = t.GetChild(0);
        }
    }
}

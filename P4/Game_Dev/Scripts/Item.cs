using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour  {
    //class references
    public InventorySlot item;
    public ItemSave itemSave;

    //stats
    public float weight;
    public bool consumable;
    public bool equipable;



    private void Awake()
    {
        weight = itemSave.weight;
        consumable = itemSave.consumable;
        equipable = itemSave.equipable;

    }

    void Start () {
		
	}
	
	void Update () {
		
	}
}

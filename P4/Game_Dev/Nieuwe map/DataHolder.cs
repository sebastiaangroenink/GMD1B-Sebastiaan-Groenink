using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class DataHolder  {
          //serializes ItemSave and InventorySlot when game is closed
    public List<ItemSave> itemData = new List<ItemSave>();
    public List<InventorySlot> invSlots = new List<InventorySlot>();
}

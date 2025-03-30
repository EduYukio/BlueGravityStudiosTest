using System.Collections.Generic;

[System.Serializable]
public class InventorySlotData
{
    public int slotIndex;
    public string itemName;
}

[System.Serializable]
public class InventorySaveData
{
    public List<InventorySlotData> slots = new();
}
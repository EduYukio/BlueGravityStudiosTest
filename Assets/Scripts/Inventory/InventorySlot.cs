[System.Serializable]
public class InventorySlot
{
    public Item item;
    public bool IsEmpty => item == null;
}
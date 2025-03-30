[System.Serializable]
public class InventorySlot
{
    public Item item;
    public bool IsEmpty
    {
        get { return item == null; }
    }
}
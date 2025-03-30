using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int size = 10;
    public InventorySlot[] slots;

    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        slots = new InventorySlot[size];
        for (int i = 0; i < size; i++)
            slots[i] = new InventorySlot();
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].IsEmpty)
            {
                slots[i].item = item;

                //improve with event calls
                FindAnyObjectByType<InventoryUI>().Refresh();
                return true;
            }
        }
        return false; // inventory is full, add feedback
    }

    public void Swap(int indexA, int indexB)
    {
        (slots[indexA].item, slots[indexB].item) = (slots[indexB].item, slots[indexA].item);
    }

    public Item GetItem(int index)
    {
        return slots[index].item;
    }
}

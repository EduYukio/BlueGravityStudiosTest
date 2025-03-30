using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public int size = 10;
    public Dictionary<int, InventorySlot> slots = new();

    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < size; i++)
        {
            slots[i] = new InventorySlot();
        }
    }

    public bool AddItem(Item item)
    {
        foreach (var pair in slots)
        {
            if (pair.Value.IsEmpty)
            {
                slots[pair.Key].item = item;

                // improve with events later
                FindAnyObjectByType<InventoryUI>().Refresh();
                return true;
            }
        }

        return false; // inventory full, add feedbacks
    }

    public void Swap(int indexA, int indexB)
    {
        if (slots.ContainsKey(indexA) && slots.ContainsKey(indexB))
        {
            (slots[indexA].item, slots[indexB].item) = (slots[indexB].item, slots[indexA].item);
        }
    }

    public Item GetItem(int index)
    {
        return slots.ContainsKey(index) ? slots[index].item : null;
    }

    public Item GetItem(string name)
    {
        var slot = slots.Values.FirstOrDefault(s => s.item != null && s.item.itemName == name);
        return slot?.item;
    }
}

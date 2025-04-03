using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class Inventory : MonoBehaviour
{
    public int size = 10;
    public Dictionary<int, InventorySlot> slots = new();

    public static Action ItemAdded;
    public static Action ItemRemoved;

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

                ItemAdded?.Invoke();
                return true;
            }
        }

        return false;
    }

    public void Swap(int indexA, int indexB)
    {
        if (slots.ContainsKey(indexA) && slots.ContainsKey(indexB))
        {
            (slots[indexA].item, slots[indexB].item) = (slots[indexB].item, slots[indexA].item);
            Tooltip.Instance.HideTooltip();
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

    public void RemoveItem(int index)
    {
        if (slots.ContainsKey(index) && !slots[index].IsEmpty)
        {
            slots[index].item = null;

            ItemRemoved?.Invoke();
        }
    }

    public bool RemoveItem(string itemName)
    {
        foreach (var pair in slots)
        {
            var item = pair.Value.item;
            if (item != null && item.itemName == itemName)
            {
                slots[pair.Key].item = null;

                ItemRemoved?.Invoke();
                return true;
            }
        }

        return false;
    }
}

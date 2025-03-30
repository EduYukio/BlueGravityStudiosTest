using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class InventorySaveSystem : MonoBehaviour
{
    [SerializeField] private Item[] allItems;

    private string SavePath => Application.persistentDataPath + "/inventory.json";

    public void Save()
    {
        var data = new InventorySaveData();

        foreach (var pair in Inventory.Instance.slots)
        {
            if (pair.Value.item != null)
            {
                data.slots.Add(new InventorySlotData
                {
                    slotIndex = pair.Key,
                    itemName = pair.Value.item.itemName
                });
            }
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);
    }

    public void Load()
    {
        if (!File.Exists(SavePath)) return;

        foreach (var slot in Inventory.Instance.slots.Values)
        {
            slot.item = null;
        }

        string json = File.ReadAllText(SavePath);
        var data = JsonUtility.FromJson<InventorySaveData>(json);

        foreach (var slotData in data.slots)
        {
            var item = allItems.FirstOrDefault(i => i.itemName == slotData.itemName);
            if (item != null)
            {
                Inventory.Instance.slots[slotData.slotIndex].item = item;
            }
        }

        FindAnyObjectByType<InventoryUI>()?.Refresh();
    }
}

using UnityEngine;
using System.IO;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class InventorySaveSystem : MonoBehaviour
{
    [SerializeField] private Item[] allItems;

    private string SavePath => Application.persistentDataPath + "/inventory.json";

    public static Action LoadedGame;

    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        var data = new InventorySaveData();

        foreach (var pair in Inventory.Instance.slots)
        {
            var slot = pair.Value;
            if (!slot.IsEmpty)
            {
                var slotData = new InventorySlotData
                {
                    slotIndex = pair.Key,
                    itemName = slot.item.itemName
                };
                data.slots.Add(slotData);
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
                Inventory.Instance.AddItem(item, slotData.slotIndex);
            }
        }

        LoadedGame?.Invoke();
    }

    public void NewGame()
    {
        foreach (var slot in Inventory.Instance.slots.Values)
        {
            slot.item = null;
        }

        Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

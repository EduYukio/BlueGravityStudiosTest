using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySlotUI[] uiSlots;

    private int? selectedIndex = null;

    private void Start()
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].Setup(i, this);
        }

        Refresh();
    }

    public void OnSlotLeftClick(int index)
    {
        if (selectedIndex == null)
        {
            if (Inventory.Instance.GetItem(index) == null) return;
            selectedIndex = index;
        }
        else if (selectedIndex == index)
        {
            selectedIndex = null;
        }
        else
        {
            Inventory.Instance.Swap(selectedIndex.Value, index);
            selectedIndex = null;
            Refresh();
        }
    }

    public void OnSlotRightClick(int index)
    {
        if (selectedIndex != null && selectedIndex != index)
        {
            TryCombine(selectedIndex.Value, index);
            selectedIndex = null;
            Refresh();
        }
    }

    private void TryCombine(int a, int b)
    {
        var itemA = Inventory.Instance.GetItem(a);
        var itemB = Inventory.Instance.GetItem(b);

        if (itemA == null || itemB == null) return;

        if ((itemA.name == "Wood" && itemB.name == "String") ||
            (itemA.name == "String" && itemB.name == "Wood"))
        {
            var fishingRod = Resources.Load<Item>("FishingRod");
            Inventory.Instance.slots[a].item = null;
            Inventory.Instance.slots[b].item = fishingRod;
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].Refresh();
        }
    }
}

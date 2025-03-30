using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySlotUI[] uiSlots;

    private int? selectedIndex = null;

    // move this to a better place
    [SerializeField] private Item fishingRodItem;

    private void Start()
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].Setup(i, this);
        }

        Refresh();
    }

    private void Update()
    {
        if (selectedIndex != null && Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverUIElement())
            {
                Inventory.Instance.RemoveItem(selectedIndex.Value);
                Refresh();
            }
        }
    }

    private bool IsPointerOverUIElement()
    {
        return UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
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
            Deselect();
        }
        else
        {
            Inventory.Instance.Swap(selectedIndex.Value, index);
            Deselect();
        }
        Refresh();
    }

    public void OnSlotRightClick(int index)
    {
        if (selectedIndex != null && selectedIndex != index)
        {
            TryCombine(selectedIndex.Value, index);
            Deselect();
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
            Inventory.Instance.slots[a].item = null;
            Inventory.Instance.slots[b].item = fishingRodItem;
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].Refresh();
        }
    }

    public void Deselect()
    {
        selectedIndex = null;
    }

    public bool IsSlotSelected(int index)
    {
        return selectedIndex != null && selectedIndex == index;
    }
}

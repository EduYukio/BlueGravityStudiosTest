using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour, IPointerClickHandler
{
    public Image icon;

    private int index;
    private InventoryUI inventoryUI;

    public void Setup(int i, InventoryUI ui)
    {
        index = i;
        inventoryUI = ui;
        Refresh();
    }

    public void Refresh()
    {
        var item = Inventory.Instance.GetItem(index);

        if (item != null)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
        }
        else
        {
            icon.enabled = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            inventoryUI.OnSlotLeftClick(index);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            inventoryUI.OnSlotRightClick(index);
        }
    }
}

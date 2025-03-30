using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public Image outline;

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

        if (inventoryUI != null)
        {
            outline.enabled = inventoryUI.IsSlotSelected(index);
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        var item = Inventory.Instance.GetItem(index);
        if (item != null)
        {
            Tooltip.Instance.ShowTooltip(item.itemDescription);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.Instance.HideTooltip();
    }
}

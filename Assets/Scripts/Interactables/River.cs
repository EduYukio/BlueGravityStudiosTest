using UnityEngine;

public class River : MonoBehaviour, IInteractable
{
    [SerializeField] private Item fishItem;

    public void Interact()
    {
        if (Inventory.Instance.GetItem("FishingRod"))
        {
            Inventory.Instance.AddItem(fishItem);
        }
    }
}
using UnityEngine;

public class TreeObject : MonoBehaviour, IInteractable
{
    [SerializeField] private Item woodItem;

    public void Interact()
    {
        Inventory.Instance.AddItem(woodItem);
    }
}
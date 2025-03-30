using UnityEngine;


public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private Item stringItem;

    public void Interact()
    {

        if (Inventory.Instance.GetItem("Fish"))
        {
            Inventory.Instance.RemoveItem("Fish");
            //dialog = thanks, you win etc
        }
        else if (Inventory.Instance.GetItem("String") || Inventory.Instance.GetItem("FishingRod"))
        {
            //dialog im hungry, need a fish
        }
        else
        {
            Inventory.Instance.AddItem(stringItem);
            //dialog here is a string that i found, could you give me a fish?
        }
    }
}
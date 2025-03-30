using TMPro;
using UnityEngine;


public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private Item stringItem;
    GameObject speechText;

    public void Start()
    {
        speechText = GameObject.Find("SpeechText");
        speechText.GetComponent<TextMeshPro>().text = "Hello!";
    }

    public void Interact()
    {

        if (Inventory.Instance.GetItem("Fish"))
        {
            Inventory.Instance.RemoveItem("Fish");
            speechText.GetComponent<TextMeshPro>().text = "Yumm, nice fish!!\nThanks ♥";
        }
        else if (Inventory.Instance.GetItem("String") || Inventory.Instance.GetItem("FishingRod"))
        {
            speechText.GetComponent<TextMeshPro>().text = "I'm Hungry =(\nCan you get me a fish?";
        }
        else
        {
            Inventory.Instance.AddItem(stringItem);
            speechText.GetComponent<TextMeshPro>().text = "Here, I found this string.\nI'm so Hungry =(";
        }
    }
}
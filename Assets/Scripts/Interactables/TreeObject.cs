using UnityEngine;

public class TreeObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacted with tree");
    }
}
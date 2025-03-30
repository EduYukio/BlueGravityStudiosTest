using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite icon;
}

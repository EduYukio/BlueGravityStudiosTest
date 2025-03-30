using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InventorySaveSystem saveSystem;

    private void Awake()
    {
        saveSystem = FindAnyObjectByType<InventorySaveSystem>();
    }

    private void Start()
    {
        saveSystem.Load();
    }

    private void OnApplicationQuit()
    {
        saveSystem.Save();
    }
}

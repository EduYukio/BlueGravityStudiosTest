using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public static Tooltip Instance;

    [SerializeField] private GameObject tooltipPanel;
    [SerializeField] private TextMeshProUGUI tooltipText;

    Vector3 offset = new(0f, 165f, 0);
    private void Awake()
    {
        Instance = this;
        HideTooltip();
    }

    private void Update()
    {
        if (tooltipPanel.activeSelf)
        {
            tooltipPanel.transform.position = Input.mousePosition + offset;
        }
    }

    public void ShowTooltip(string text)
    {
        tooltipText.text = text;
        tooltipPanel.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }
}

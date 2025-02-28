using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class InventoryManager : MonoBehaviour
{
    public InventoryScriptableObject inventoryScriptableObject;
    public Transform inventoryContainer;
    public GameObject itemPrefab;

    private void Start()
    {
        initialize();
    }

    public void initialize()
    {
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            itemPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventoryScriptableObject.items[i]._amount.ToString();
            itemPrefab.transform.GetChild(1).GetComponent<Image>().sprite = inventoryScriptableObject.items[i]._sprite;
            GameObject item = Instantiate(itemPrefab, inventoryContainer);
        }
    }
}

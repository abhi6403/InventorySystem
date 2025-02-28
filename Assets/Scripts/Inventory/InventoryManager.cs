using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    public InventoryScriptableObject inventoryScriptableObject;
    public Transform inventoryContainer;

    private void Start()
    {
        initialize();
    }

    public void initialize()
    {
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            GameObject itemPrefab = inventoryScriptableObject.items[i].prefab;
            itemPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventoryScriptableObject.items[i]._amount.ToString();
            GameObject item = Instantiate(itemPrefab, inventoryContainer);
        }
    }
}

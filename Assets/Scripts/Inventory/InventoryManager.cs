using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class InventoryManager : MonoBehaviour
{
    public InventoryScriptableObject inventoryScriptableObject;
    public ItemService itemService;
    public Transform itemContainer;

    public void AllInventoryItems()
    {
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            string priceText = inventoryScriptableObject.items[i]._amount;
            string itemName = inventoryScriptableObject.items[i]._name;
            string itemDescription = inventoryScriptableObject.items[i]._description;
            Sprite sprite = inventoryScriptableObject.items[i]._sprite;
            itemService.Initialize(sprite,itemName,itemDescription,priceText);
            ItemService itemSer = GameObject.Instantiate(itemService, itemContainer);
        }
    }
    
    public void SortInventoryItem(ItemTypes itemType)
    {
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if(inventoryScriptableObject.items[i]._itemType == itemType)
            {
                string priceText = inventoryScriptableObject.items[i]._amount;
                string itemName = inventoryScriptableObject.items[i]._name;
                string itemDescription = inventoryScriptableObject.items[i]._description;
                Sprite sprite = inventoryScriptableObject.items[i]._sprite;
                itemService.Initialize(sprite,itemName,itemDescription,priceText);
                ItemService itemSer = GameObject.Instantiate(itemService, itemContainer);
            }
        }
    }
    
    public void clearAllItems()
    {
        foreach (Transform child in itemContainer )
        {
            Destroy(child.gameObject);
        }
    }
}

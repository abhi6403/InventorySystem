using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class InventoryManager : MonoBehaviour
{
    public InventoryScriptableObject inventoryScriptableObject;
    public Transform itemContainer;
    public ItemView itemView;

    public void AllInventoryItems()
    {
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            int itemPrice = inventoryScriptableObject.items[i]._amount;
            string itemName = inventoryScriptableObject.items[i]._name;
            string itemDescription = inventoryScriptableObject.items[i]._description;
            int itemQuantity = inventoryScriptableObject.items[i]._quantity;
            int itemWeight = inventoryScriptableObject.items[i]._weight;
            Sprite sprite = inventoryScriptableObject.items[i]._sprite;
            Transform itemTransform = itemContainer.transform;
            
            ItemModel itemModel = new ItemModel(sprite,itemName,itemDescription,itemPrice,itemQuantity,itemWeight,itemTransform);
            ItemController itemController = new ItemController(itemModel,itemView);
        }
    }
    
    public void SortInventoryItem(ItemTypes itemType)
    {
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if(inventoryScriptableObject.items[i]._itemType == itemType)
            {
                int itemPrice = inventoryScriptableObject.items[i]._amount;
                string itemName = inventoryScriptableObject.items[i]._name;
                string itemDescription = inventoryScriptableObject.items[i]._description;
                int itemQuantity = inventoryScriptableObject.items[i]._quantity;
                Sprite sprite = inventoryScriptableObject.items[i]._sprite;
                int itemWeight = inventoryScriptableObject.items[i]._weight;
                Transform itemTransform = itemContainer.transform;

                ItemModel itemModel = new ItemModel(sprite,itemName,itemDescription,itemPrice,itemQuantity,itemWeight,itemTransform);
                ItemController itemController = new ItemController(itemModel,itemView);
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

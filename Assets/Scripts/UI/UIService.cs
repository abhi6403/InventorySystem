using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    public InventoryScriptableObject inventoryScriptableObject;
    public Transform inventoryContainer;
    public ItemService itemService;

    public void initialize()
    {
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            string priceText = inventoryScriptableObject.items[i]._amount;
            string itemName = inventoryScriptableObject.items[i]._name;
            string itemDescription = inventoryScriptableObject.items[i]._description;
            Sprite sprite = inventoryScriptableObject.items[i]._sprite;
            itemService.Initialize(inventoryScriptableObject.items[i]._sprite,itemName,itemDescription,priceText);
            ItemService itemSer = GameObject.Instantiate(itemService, inventoryContainer);
        }
    }

    public void getAllItems()
    {
        initialize();
    }

    public void getWeaponItems()
    {
        clearAllItems();
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.WEAPON)
            {
                string priceText = inventoryScriptableObject.items[i]._amount;
                string itemName = inventoryScriptableObject.items[i]._name;
                string itemDescription = inventoryScriptableObject.items[i]._description;
                Sprite sprite = inventoryScriptableObject.items[i]._sprite;
                itemService.Initialize(sprite,itemName,itemDescription,priceText);
                ItemService itemSer = GameObject.Instantiate(itemService, inventoryContainer);
            }
        }
    }

    public void getFoodItems()
    {
        clearAllItems();

        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.HEALTH)
            {
                string priceText = inventoryScriptableObject.items[i]._amount;
                string itemName = inventoryScriptableObject.items[i]._name;
                string itemDescription = inventoryScriptableObject.items[i]._description;
                Sprite sprite = inventoryScriptableObject.items[i]._sprite;
                itemService.Initialize(sprite,itemName,itemDescription,priceText);
                ItemService itemSer = GameObject.Instantiate(itemService, inventoryContainer);
            }
        }
    }

    public void getDevilFruits()
    {
        clearAllItems();
        
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.DEVILFRUIT)
            {
                string priceText = inventoryScriptableObject.items[i]._amount;
                string itemName = inventoryScriptableObject.items[i]._name;
                string itemDescription = inventoryScriptableObject.items[i]._description;
                Sprite sprite = inventoryScriptableObject.items[i]._sprite;
                itemService.Initialize(sprite,itemName,itemDescription,priceText);
                ItemService itemSer = GameObject.Instantiate(itemService, inventoryContainer);
            }
        }
    }

    public void getPosters()
    {
        clearAllItems();
        
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.POSTER)
            {
                string priceText = inventoryScriptableObject.items[i]._amount;
                string itemName = inventoryScriptableObject.items[i]._name;
                string itemDescription = inventoryScriptableObject.items[i]._description;
                Sprite sprite = inventoryScriptableObject.items[i]._sprite;
                itemService.Initialize(sprite,itemName,itemDescription,priceText);
                ItemService itemSer = GameObject.Instantiate(itemService, inventoryContainer);
            }
        }
    }
    
    public void getProps()
    {
        clearAllItems();
        
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.PROPS)
            {
                string priceText = inventoryScriptableObject.items[i]._amount;
                string itemName = inventoryScriptableObject.items[i]._name;
                string itemDescription = inventoryScriptableObject.items[i]._description;
                Sprite sprite = inventoryScriptableObject.items[i]._sprite;
                itemService.Initialize(sprite,itemName,itemDescription,priceText);
                ItemService itemSer = GameObject.Instantiate(itemService, inventoryContainer);
            }
        }
    }
    
    public void getPotions()
    {
        clearAllItems();
        
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.POTION)
            {
                string priceText = inventoryScriptableObject.items[i]._amount;
                string itemName = inventoryScriptableObject.items[i]._name;
                string itemDescription = inventoryScriptableObject.items[i]._description;
                Sprite sprite = inventoryScriptableObject.items[i]._sprite;
                itemService.Initialize(sprite,itemName,itemDescription,priceText);
                ItemService itemSer = GameObject.Instantiate(itemService, inventoryContainer);
            }
        }
    }
    
    public void getShipItems()
    {
        clearAllItems();
        
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.SHIPITEMS)
            {
                string priceText = inventoryScriptableObject.items[i]._amount;
                string itemName = inventoryScriptableObject.items[i]._name;
                string itemDescription = inventoryScriptableObject.items[i]._description;
                Sprite sprite = inventoryScriptableObject.items[i]._sprite;
                itemService.Initialize(sprite,itemName,itemDescription,priceText);
                ItemService itemSer = GameObject.Instantiate(itemService, inventoryContainer);
            }
        }
    }
    
    public void getMap()
    {
        clearAllItems();
        
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.MAP)
            {
                Sprite sprite = inventoryScriptableObject.items[i]._sprite;
                string priceText = inventoryScriptableObject.items[i]._amount;
                string itemName = inventoryScriptableObject.items[i]._name;
                string itemDescription = inventoryScriptableObject.items[i]._description;
                itemService.Initialize(sprite,itemName,itemDescription,priceText);
                ItemService itemSer = GameObject.Instantiate(itemService, inventoryContainer);
            }
        }
    }

    public void clearAllItems()
    {
        foreach (Transform child in inventoryContainer )
        {
            Destroy(child.gameObject);
        }
    }
}

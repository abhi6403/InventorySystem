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
    
    public InventoryManager inventoryManager;
    
    

    public void getAllItems()
    {
        inventoryManager.AllInventoryItems();
    }

    public void getWeaponItems()
    {
        clearAllItems();
        
        inventoryManager.SortInventoryItem(ItemTypes.WEAPON);
        
    }

    public void getFoodItems()
    {
        clearAllItems();

        inventoryManager.SortInventoryItem(ItemTypes.HEALTH);
    }

    public void getDevilFruits()
    {
        clearAllItems();
        
        inventoryManager.SortInventoryItem(ItemTypes.DEVILFRUIT);
    }

    public void getPosters()
    {
        clearAllItems();
        
        inventoryManager.SortInventoryItem(ItemTypes.POSTER);
    }
    
    public void getProps()
    {
        clearAllItems();
        
        inventoryManager.SortInventoryItem(ItemTypes.PROPS);
    }
    
    public void getPotions()
    {
        clearAllItems();
        
        inventoryManager.SortInventoryItem(ItemTypes.POTION);
    }
    
    public void getShipItems()
    {
        clearAllItems();
        
        inventoryManager.SortInventoryItem(ItemTypes.SHIPITEMS);
    }
    
    public void getMap()
    {
        clearAllItems();
        
        inventoryManager.SortInventoryItem(ItemTypes.MAP);
    }

    public void clearAllItems()
    {
        foreach (Transform child in inventoryContainer )
        {
            Destroy(child.gameObject);
        }
    }
}

using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    public InventoryScriptableObject inventoryScriptableObject;
    public Transform inventoryContainer;
    public InventoryView inventoryView;
    
    public void getAllItems()
    {
        InventoryModel inventoryModel = new InventoryModel(inventoryScriptableObject, inventoryContainer);
        InventoryController inventoryController = new InventoryController(inventoryModel,inventoryView);
        //inventoryManager.AllInventoryItems();
    }

    public void getWeaponItems()
    {
        //inventoryManager.clearAllItems();
        //inventoryManager.SortInventoryItem(ItemTypes.WEAPON);
        
    }
    public void getFoodItems()
    {
        //inventoryManager.clearAllItems();
        //inventoryManager.SortInventoryItem(ItemTypes.HEALTH);
    }

    public void getDevilFruits()
    {
        //inventoryManager.clearAllItems();
        //inventoryManager.SortInventoryItem(ItemTypes.DEVILFRUIT);
    }

    public void getPosters()
    {
        //inventoryManager.clearAllItems();
        //inventoryManager.SortInventoryItem(ItemTypes.POSTER);
    }
    
    public void getProps()
    {
        //inventoryManager.clearAllItems();
        //inventoryManager.SortInventoryItem(ItemTypes.PROPS);
    }
    
    public void getPotions()
    {
        //inventoryManager.clearAllItems();
        //inventoryManager.SortInventoryItem(ItemTypes.POTION);
    }
    
    public void getShipItems()
    {
        //inventoryManager.clearAllItems();
        //inventoryManager.SortInventoryItem(ItemTypes.SHIPITEMS);
    }
    
    public void getMap()
    {
        //inventoryManager.clearAllItems();
        //inventoryManager.SortInventoryItem(ItemTypes.MAP);
    }
}

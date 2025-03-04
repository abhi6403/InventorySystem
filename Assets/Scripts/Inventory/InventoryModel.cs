using System.Collections.Generic;
using UnityEngine;

public class InventoryModel 
{
    private InventoryController inventoryController;

    private InventoryScriptableObject inventoryscriptableObject;
    private List<ItemsScriptableObject> playerInventoryItems;
    private Transform inventoryTransform;

    public InventoryModel(InventoryScriptableObject _inventoryscriptableObject, Transform _inventoryTransform)
    {
        inventoryscriptableObject = _inventoryscriptableObject;
        inventoryTransform = _inventoryTransform;
    }

    public InventoryModel(List<ItemsScriptableObject> _playerInventoryItems, Transform _inventoryTransform)
    {
        playerInventoryItems = _playerInventoryItems;
        inventoryTransform = _inventoryTransform;
        Debug.Log("Player inventory list loaded");
    }
    public void SetInventoryController(InventoryController _inventoryController)
    {
        inventoryController = _inventoryController;
    }

    public InventoryScriptableObject GetInventoryscriptableObject()
    {
        return inventoryscriptableObject;
    }

    public Transform GetInventoryTransform()
    {
        return inventoryTransform;
    }

    public List<ItemsScriptableObject> GetPlayerInventoryItems()
    {
        return playerInventoryItems;
    }
}

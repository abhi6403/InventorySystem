using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Object;

public class InventoryController
{
    private InventoryView inventoryView;
    private InventoryModel inventoryModel;

    public InventoryController( InventoryModel _inventoryModel,InventoryView _inventoryView)
    {
        inventoryModel = _inventoryModel;
        inventoryView = _inventoryView;
        
        inventoryModel.SetInventoryController(this);
        inventoryView.SetInventoryController(this);
    }

    public void ShowInventory()
    {
        inventoryView.clearAllItems();
        
        for (int i = 0; i < GetInventoryScriptableObject().items.Count; i++)
        {
            ItemModel itemModel = new ItemModel(GetInventoryScriptableObject().items[i], GetInventoryTransform());
            ItemController itemController = new ItemController(itemModel,GetItemView());
        }
    }

    public void ShowInventoryItem(ItemTypes itemType)
    {
        inventoryView.clearAllItems();
        
        for (int i = 0; i < GetInventoryScriptableObject().items.Count; i++)
        {
            if(GetInventoryScriptableObject().items[i]._itemType == itemType)
            {
                ItemModel itemModel = new ItemModel(GetInventoryScriptableObject().items[i], GetInventoryTransform());
                ItemController itemController = new ItemController(itemModel,GetItemView());
            }
        }
    }

    public void ShowPlayerInventoryItems()
    {
        inventoryView.clearAllItems();

        Debug.Log("PlayerInventoryItemsInInventoryController");
        
        for (int i = 0; i < GetPlayerInventoryItems().Count; i++)
        {
            ItemModel itemModel = new ItemModel(GetInventoryScriptableObject().items[i], GetInventoryTransform());
            ItemController itemController = new ItemController(itemModel,GetItemView());
        }
        
        
    }
    public void clearAllItems()
    {
        foreach (Transform child in GetInventoryTransform())
        {
            Destroy(child.gameObject);
        }
    }
    
    public ItemView GetItemView()
    {
        return inventoryView.GetItemView();
    }
    public InventoryScriptableObject GetInventoryScriptableObject()
    {
        return inventoryModel.GetInventoryscriptableObject();
    }

    public Transform GetInventoryTransform()
    {
        return inventoryModel.GetInventoryTransform();
    }

    public List<ItemsScriptableObject> GetPlayerInventoryItems()
    {
        return inventoryModel.GetPlayerInventoryItems();
    }
    
}

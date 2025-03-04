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
            int itemPrice = GetInventoryScriptableObject().items[i]._amount;
            string itemName = GetInventoryScriptableObject().items[i]._name;
            string itemDescription = GetInventoryScriptableObject().items[i]._description;
            int itemQuantity = GetInventoryScriptableObject().items[i]._quantity;
            int itemWeight = GetInventoryScriptableObject().items[i]._weight;
            Sprite sprite = GetInventoryScriptableObject().items[i]._sprite;
            Transform itemTransform = GetInventoryTransform().transform;
            
            ItemModel itemModel = new ItemModel(sprite,itemName,itemDescription,itemPrice,itemQuantity,itemWeight,itemTransform);
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
                int itemPrice = GetInventoryScriptableObject().items[i]._amount;
                string itemName = GetInventoryScriptableObject().items[i]._name;
                string itemDescription = GetInventoryScriptableObject().items[i]._description;
                int itemQuantity = GetInventoryScriptableObject().items[i]._quantity;
                Sprite sprite = GetInventoryScriptableObject().items[i]._sprite;
                int itemWeight = GetInventoryScriptableObject().items[i]._weight;
                Transform itemTransform = GetInventoryTransform().transform;

                ItemModel itemModel = new ItemModel(sprite,itemName,itemDescription,itemPrice,itemQuantity,itemWeight,itemTransform);
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
            int itemPrice = GetPlayerInventoryItems()[i]._amount;
            string itemName = GetPlayerInventoryItems()[i]._name;
            string itemDescription = GetPlayerInventoryItems()[i]._description;
            int itemQuantity = GetPlayerInventoryItems()[i]._quantity;
            int itemWeight = GetPlayerInventoryItems()[i]._weight;
            Sprite sprite = GetPlayerInventoryItems()[i]._sprite;
            Transform itemTransform = GetInventoryTransform().transform;
            
            ItemModel itemModel = new ItemModel(sprite,itemName,itemDescription,itemPrice,itemQuantity,itemWeight,itemTransform);
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

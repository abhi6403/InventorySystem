using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Object;

public class InventoryController
{
    private InventoryView inventoryView;
    private InventoryModel inventoryModel;
    
    private ShopService shopService;

    public InventoryController(ShopService _shopService)
    {
        shopService = _shopService;

        inventoryModel = new InventoryModel(shopService.GetShopController().GetShopScriptableObject(), shopService.GetShopController().GetShopTransform());
        inventoryView = shopService.GetShopController().GetInventoryView();
        
        inventoryModel.SetInventoryController(this);
        inventoryView.SetInventoryController(this);
        ShowInventory();
        EventService.Instance.OnButtonAllClickedEvent.AddListener(ShowInventory);
        EventService.Instance.OnFilterButtonClickedEvent.AddListener(ShowInventoryItem);
    }

    public void ShowInventory()
    {
        clearAllItems();
        
        for (int i = 0; i < GetInventoryScriptableObject().items.Count; i++)
        {
            ItemModel itemModel = new ItemModel(GetInventoryScriptableObject().items[i], GetInventoryTransform());
            ItemController itemController = new ItemController(itemModel,GetItemView());
        }
    }

    public void ShowInventoryItem(ItemTypes itemType)
    {
        clearAllItems();
        
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
        clearAllItems();

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

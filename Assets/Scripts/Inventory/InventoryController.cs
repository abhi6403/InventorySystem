using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Object;

public class InventoryController
{
    private InventoryView inventoryView;
    private InventoryModel inventoryModel;

    private ShopService shopService;
    private PlayerService playerService;

    public InventoryController(ShopService _shopService)
    {
        shopService = _shopService;

        inventoryModel = new InventoryModel();
        inventoryView = shopService.GetShopController().GetInventoryView();
        
        SetShopInventoryScriptableObject();
        inventoryModel.SetInventoryController(this);
        inventoryView.SetInventoryController(this);
        ShowInventory();
        EventService.Instance.OnButtonAllClickedEvent.AddListener(ShowInventory);
        EventService.Instance.OnFilterButtonClickedEvent.AddListener(ShowInventoryItem);
    }

    public InventoryController(PlayerService _playerService)
    {
        playerService = _playerService;
        
        inventoryModel = new InventoryModel();
        inventoryView = playerService.GetPlayerController().GetInventoryView();
        SetPlayerInventoryItem();
        
        inventoryModel.SetInventoryController(this);
        inventoryView.SetInventoryController(this);
        ShowPlayerInventoryItems();
    }

    ~InventoryController()
    {
        EventService.Instance.OnButtonAllClickedEvent.RemoveListener(ShowInventory);
        EventService.Instance.OnFilterButtonClickedEvent.RemoveListener(ShowInventoryItem);
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
        
        for (int i = 0; i < playerService.GetPlayerController().GetItemsInPlayerInventory().Count; i++)
        {
            ItemModel itemModel = new ItemModel(GetPlayerInventoryItems()[i], GetInventoryTransform());
            ItemController itemController = new ItemController(itemModel,GetItemView());
            Debug.Log("PlayerInventoryItemsInPlayerInventoryController");
        }
        
        
    }
    public void clearAllItems()
    {
        foreach (Transform child in GetInventoryTransform())
        {
            Destroy(child.gameObject);
        }
    }
    
    public void SetPlayerInventoryItem()
    {
        inventoryModel.SetPlayerInventoryItem(playerService.GetPlayerController().GetItemsInPlayerInventory(),playerService.GetPlayerController().GetPlayerInventoryTransform());
    }
    public void SetShopInventoryScriptableObject()
    {
        inventoryModel.SetInventoryScriptableObject(shopService.GetShopController().GetShopScriptableObject(),shopService.GetShopController().GetShopTransform());
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

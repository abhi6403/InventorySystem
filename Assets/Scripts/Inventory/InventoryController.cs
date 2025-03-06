using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Object;

public class InventoryController
{
    private InventoryView inventoryView;
    private InventoryModel inventoryModel;

    private ShopService shopService;
    private PlayerService playerService;
    private ItemService itemService;
    private ItemView itemView;

    public InventoryController(ShopService _shopService,ItemView _itemView,ItemService _itemService)
    {
        shopService = _shopService;
        itemService = _itemService;
        itemView = _itemView;
        inventoryModel = new InventoryModel();
        inventoryView = shopService.GetShopController().GetInventoryView();
        
        SetShopInventoryScriptableObject();
        inventoryModel.SetInventoryController(this);
        inventoryView.SetInventoryController(this);
        ShowInventory();
        EventService.Instance.OnButtonAllClickedEvent.AddListener(ShowInventory);
        EventService.Instance.OnFilterButtonClickedEvent.AddListener(ShowInventoryItem);
    }

    public InventoryController(PlayerService _playerService,ItemView _itemView,ItemService _itemService)
    {
        playerService = _playerService;
        
        inventoryModel = new InventoryModel();
        SetPlayerInventoryItem();
        inventoryView = playerService.GetPlayerController().GetInventoryView();
 
        
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
            itemService = new ItemService(itemView,GetInventoryScriptableObject().items[i], GetInventoryTransform());
        }
    }

    public void ShowInventoryItem(ItemTypes itemType)
    {
        clearAllItems();
        
        for (int i = 0; i < GetInventoryScriptableObject().items.Count; i++)
        {
            if(GetInventoryScriptableObject().items[i]._itemType == itemType)
            {
                itemService = new ItemService(itemView,GetInventoryScriptableObject().items[i], GetInventoryTransform());
            }
        }
    }

    public void ShowPlayerInventoryItems()
    {
        //clearAllItems();
       
            /*for (int i = 0; i < playerService.GetPlayerController().GetItemsInPlayerInventory().Count; i++)
            {
                
            }*/
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

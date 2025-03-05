using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    private PlayerView playerView;
    
    
    private InventoryService inventoryService;

    public PlayerController(PlayerView _playerView, InventoryService _inventoryService)
    {
        inventoryService = _inventoryService;
        playerView = _playerView;
        playerView.SetPlayerController(this);
        EventService.Instance.OnBuyButtonClickedEvent.AddListener(AddToPlayerInventory);
        
    }

    public void AddToPlayerInventory(ItemsScriptableObject _itemsScriptableObject)
    {
        if (OnBuyItems(_itemsScriptableObject) == false)
        {
            GetItemsInPlayerInventory().Add(_itemsScriptableObject);
            inventoryService.GetInventoryController().ShowPlayerInventoryItems();
        }
    }

    public bool OnBuyItems(ItemsScriptableObject _itemsScriptableObject)
    {
        bool added = false;

        for (int i = 0; i < GetItemsInPlayerInventory().Count; i++)
        {
            if (GetItemsInPlayerInventory()[i] == _itemsScriptableObject)
            {
                Debug.Log("Item is already added to player inventory");
                added = true;
                break;
            }
        }
        inventoryService.GetInventoryController().ShowPlayerInventoryItems();
        return added;
    }
    
    public List<ItemsScriptableObject> GetItemsInPlayerInventory()
    {
       return playerView.GetItemsInPlayerInventory();
    }

    public InventoryView GetInventoryView()
    {
        return playerView.GetInventoryView();
    }
    public Transform GetPlayerInventoryTransform()
    {
        return playerView.GetPlayerInventoryTransform();
    }
}

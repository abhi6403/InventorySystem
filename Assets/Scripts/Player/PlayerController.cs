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
        GetItemsInPlayerInventory().Add(_itemsScriptableObject);
        inventoryService.GetInventoryController().ShowPlayerInventoryItems();
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
        Debug.Log("Getting player inventory transform");
        return playerView.GetPlayerInventoryTransform();
    }
}

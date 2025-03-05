using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    //private PlayerModel playerModel;
    private PlayerView playerView;
    
    
    private InventoryService inventoryService;

    public PlayerController(PlayerView _playerView, InventoryService _inventoryService)
    {
        inventoryService = _inventoryService;
        playerView = _playerView;
        playerView.SetPlayerController(this);
        
    }
    
    /*public InventoryController  SetInventory()
    {
        InventoryModel inventoryModel = new InventoryModel(playerModel.GetPlayerInventoryItems(),playerView.GetPlayerInventoryTransform());
        InventoryController inventoryController = new InventoryController(inventoryModel,playerView.GetInventoryView());
        return inventoryController;
    }*/

    public void ShowItemsInPlayerInventory()
    {
            //SetInventory().ShowPlayerInventoryItems();
            Debug.Log("Showing items in player inventory");
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

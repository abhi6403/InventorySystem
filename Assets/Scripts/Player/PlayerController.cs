using UnityEngine;

public class PlayerController 
{
    private PlayerModel playerModel;
    private PlayerView playerView;

    public PlayerController(PlayerModel _playerModel, PlayerView _playerView)
    {
        playerModel = _playerModel;
        playerView = _playerView;
        
        playerModel.SetPlayerController(this);
        playerView.SetPlayerController(this);
        
    }
    
    public InventoryController  SetInventory()
    {
        InventoryModel inventoryModel = new InventoryModel(playerModel.GetPlayerInventoryItems(),playerView.GetPlayerInventoryTransform());
        InventoryController inventoryController = new InventoryController(inventoryModel,playerView.GetInventoryView());
        return inventoryController;
    }

    public void ShowItemsInPlayerInventory()
    {
            SetInventory().ShowPlayerInventoryItems();
            Debug.Log("Showing items in player inventory");
    }
}

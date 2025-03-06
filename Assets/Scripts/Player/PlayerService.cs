using UnityEngine;

public class PlayerService 
{
    private PlayerController playerController;
    public void Initialize(PlayerView _playerView,InventoryService _inventoryService,ItemView _itemView)
    {
        playerController = new PlayerController(_playerView, _inventoryService,_itemView);
    }

    public PlayerController GetPlayerController()
    {
        return playerController;
    }
}

using UnityEngine;

public class PlayerService 
{
    private PlayerController playerController;
    public void Initialize(PlayerView _playerView,InventoryService _inventoryService)
    {
        playerController = new PlayerController(_playerView, _inventoryService);
    }

    public PlayerController GetPlayerController()
    {
        return playerController;
    }
}

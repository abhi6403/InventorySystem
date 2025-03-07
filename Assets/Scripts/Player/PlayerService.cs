using UnityEngine;

public class PlayerService 
{
    private PlayerController playerController;
    public void Initialize(PlayerView _playerView,ItemView _itemView,ItemService _itemService)
    {
        playerController = new PlayerController(_playerView,_itemView,_itemService);
    }

    public PlayerController GetPlayerController()
    {
        return playerController;
    }
}

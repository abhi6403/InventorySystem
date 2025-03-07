using UnityEngine;

public class PlayerService 
{
    private PlayerController playerController;
    public void Initialize(PlayerView _playerView,ItemView _itemView)
    {
        playerController = new PlayerController(_playerView,_itemView);
    }

    public PlayerController GetPlayerController()
    {
        return playerController;
    }
}

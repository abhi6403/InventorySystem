using System.Collections.Generic;
using UnityEngine;

public class PlayerModel 
{
    private PlayerController playerController;

    private List<ItemsScriptableObject> playerItems;
    
    public void SetPlayerController(PlayerController _playerController)
    {
        playerController = _playerController;
    }
    
    public List<ItemsScriptableObject> GetPlayerInventoryItems()
    {
        return playerItems;
    }
}

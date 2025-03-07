using UnityEngine;

public class PlayerService 
{
    private PlayerController playerController;
    public void Initialize(PlayerView _playerView,ItemView _itemView,ItemService _itemService,ShopService _shopService)
    {
        playerController = new PlayerController(_playerView,_itemView,_itemService,_shopService);
    }

    public int GetSelectionQuantity()
    {
        return playerController.GetSelectionQuantity();
    }
    
    public void SetSelectionQuantity(int quantity)
    {
        playerController.SetSelectionQuantity(quantity);
    }

    public int GetTotalBerries()
    {
        return playerController.GetTotalBerries();
    }

    public void SetTotalBerries(int totalBerries)
    {
        playerController.SetTotalBerries(totalBerries);
    }
}

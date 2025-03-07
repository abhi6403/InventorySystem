

public class PlayerService 
{
    private PlayerController playerController;
    public void Initialize(PlayerView _playerView,ItemView _itemView,ItemService _itemService,ShopService _shopService,UIService _uiService)
    {
        playerController = new PlayerController(_playerView,_itemView,_itemService,_shopService,_uiService);
    }

    public int GetSelectionQuantity()
    {
        return playerController.GetSelectionQuantity();
    }
    
    public void SetSelectionQuantity(int quantity)
    {
        playerController.SetSelectionQuantity(quantity);
    }

    public void DecreaseTotalWeight(int _totalWeight)
    {
        playerController.DecreaseTotalWeight(_totalWeight);
    }

    public void IncreaseTotalWeight(int _totalWeight)
    {
        playerController.IncreaseTotalWeight(_totalWeight);
    }
    public int GetTotalBerries()
    {
        return playerController.GetTotalBerries();
    }

    public int GetTotalWeight()
    {
        return playerController.GetTotalWeight();
    }

    public int GetMaxWeight()
    {
        return playerController.GetMaxWeight();
    }
}

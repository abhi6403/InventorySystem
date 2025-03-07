using UnityEngine;

public class ShopService 
{
    private ShopController shopController;
    public void Initialize(ShopView shopView,ItemView _itemView,ItemService _itemService,PlayerService playerService)
    {
        shopController = new ShopController(shopView,_itemView,_itemService,playerService);
    }

    public int GetSelectionQuantity()
    {
        return shopController.GetSelectedQuantity();
    }

    public void SetSelectionQuantity(int quantity)
    {
        shopController.SetSelectionQuantity(quantity);
    }
}

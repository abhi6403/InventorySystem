using UnityEngine;

public class ShopService 
{
    private ShopController shopController;
    public void Initialize(ShopView shopView,ItemView _itemView,ItemService _itemService)
    {
        shopController = new ShopController(shopView,_itemView,_itemService);
    }
    public ShopController GetShopController()
    {
        return shopController;
    }
}

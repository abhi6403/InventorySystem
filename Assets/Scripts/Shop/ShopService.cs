using UnityEngine;

public class ShopService 
{
    private ShopController shopController;
    public void Initialize(ShopView shopView,InventoryService inventoryService)
    {
        shopController = new ShopController(shopView, inventoryService);
    }
    public ShopController GetShopController()
    {
        return shopController;
    }
}

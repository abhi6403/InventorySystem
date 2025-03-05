using UnityEngine;

public class ShopController 
{
    private ShopView shopView;
    private InventoryService inventoryService;

    public ShopController(ShopView _shopView, InventoryService _inventoryService)
    {
        shopView = _shopView;
        inventoryService = _inventoryService;
        shopView.SetShopController(this);
    }
    
    public Transform GetShopTransform()
    {
        return shopView.GetShopTransform();
    }

    public InventoryScriptableObject GetShopScriptableObject()
    {
        return shopView.GetShopInventoryObject();
    }

    public InventoryView GetInventoryView()
    {
        return shopView.GetInventoryView();
    }
}

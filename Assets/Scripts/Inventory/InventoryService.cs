using UnityEngine;

public class InventoryService
{
    private InventoryController inventoryController;
    public void Initialize(ShopService shopService)
    {
        inventoryController = new InventoryController(shopService);
    }

    public InventoryController GetInventoryController()
    {
        return inventoryController;
    }
    
}

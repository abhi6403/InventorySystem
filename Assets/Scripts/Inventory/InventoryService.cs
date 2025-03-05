using UnityEngine;

public class InventoryService
{
    private InventoryController inventoryController;
    public void Initialize(ShopService shopService,PlayerService playerService)
    {
        inventoryController = new InventoryController(shopService);
        inventoryController = new InventoryController(playerService);
    }

    public InventoryController GetInventoryController()
    {
        return inventoryController;
    }
    
}

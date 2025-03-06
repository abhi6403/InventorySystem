using UnityEngine;

public class InventoryService
{
    private InventoryController inventoryController;
    public void Initialize(ShopService shopService,PlayerService playerService,ItemView _itemView,ItemService _itemService)
    {
        inventoryController = new InventoryController(shopService,_itemView,_itemService);
        inventoryController = new InventoryController(playerService,_itemView,_itemService);
    }

    public InventoryController GetInventoryController()
    {
        return inventoryController;
    }
    
}

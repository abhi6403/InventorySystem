using System;
using UnityEngine;

public class GameService : MonoBehaviour
{
    private ItemService itemService;
    private ShopService shopService;
    private InventoryService inventoryService;
    private UIService uiService;
    private PlayerService playerService;
    private EventService eventService;

    [SerializeField]
    private ShopView shopView;
    void Start()
    {
        CreateServices();
        InjectDependencies();
    }

    private void CreateServices()
    {
        eventService = new EventService();
        itemService = new ItemService();
        shopService = new ShopService();
        inventoryService = new InventoryService();
        playerService = new PlayerService();
    }

    private void InjectDependencies()
    {
        itemService.Initialize();
        shopService.Initialize(shopView);
        inventoryService.Initialize();
        playerService.Initialize();
    }
}

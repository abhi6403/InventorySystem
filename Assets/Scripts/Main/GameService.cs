using System;
using UnityEngine;

public class GameService : MonoBehaviour
{
    public ItemService itemService;
    public ShopService shopService;
    public InventoryService inventoryService;
    public UIService uiService;
    public PlayerService playerService;
    public EventService eventService;

    [SerializeField]
    private ShopView shopView;
    [SerializeField]
    private PlayerView playerView;
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
        
        shopService.Initialize(shopView,inventoryService);
        inventoryService.Initialize(shopService);
        playerService.Initialize();
        itemService.Initialize();
    }
}

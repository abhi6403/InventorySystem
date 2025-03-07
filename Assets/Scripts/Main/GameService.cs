using System;
using UnityEngine;

public class GameService : MonoBehaviour
{
    public ItemService itemService;
    public ShopService shopService;
    public PlayerService playerService;
    public EventService eventService;

    [SerializeField]
    private ShopView shopView;
    [SerializeField]
    private PlayerView playerView;
    [SerializeField]
    private ItemView itemView;
    void Start()
    {
        CreateServices();
        InjectDependencies();
    }

    private void CreateServices()
    {
        eventService = new EventService();
        shopService = new ShopService();
        playerService = new PlayerService();
        itemService = new ItemService();
    }

    private void InjectDependencies()
    {
        shopService.Initialize(shopView,itemView,itemService);
        playerService.Initialize(playerView,itemView,itemService);
    }
}

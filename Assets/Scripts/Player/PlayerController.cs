using System.Collections.Generic;
using TMPro;
using static UnityEngine.Object;
using UnityEngine;

public class PlayerController 
{
    private PlayerView playerView;
    private PlayerModel playerModel;
    private ItemView itemView;
    private ItemService itemService;

    public PlayerController(PlayerView _playerView, ItemView _itemView,ItemService _itemService)
    {
        playerView = _playerView;
        playerModel = new PlayerModel();
        itemView = _itemView;
        itemService = _itemService;
        playerView.SetPlayerController(this);
        playerModel.SetController(this);
        PopulateList();
        EventService.Instance.OnBuyEvent.AddListener(BuyItem);
    }

    public void PopulatePlayerInventory()
    {
        for (int i = 0; i < playerModel.PlayerItemList.Count; i++)
        {
            playerModel.PlayerItemList[i].ShowItem();
            
        }
    }
    public void PopulateList()
    {
        for (int i = 0; i < GetInventoryObject().items.Count; i++)
        {
            ItemController itemController = itemService.CreateItem(GetInventoryObject().items[i],itemView,GetPlayerTransform(),ItemParentType.PLAYER);
            playerModel.AddItem(itemController);
        }
    }

    public void BuyItem(ItemModel item)
    {
        for (int i = 0; i < playerModel.PlayerItemList.Count; i++)
        {
            if (playerModel.PlayerItemList[i].GetItemName() == item.GetItemName())
            {
                playerModel.PlayerItemList[i].ShowItem();
            }
        }
    }
   
    public Transform GetPlayerTransform()
    {
        return playerView.GetPlayerTransform();
    }

    public InventoryScriptableObject GetInventoryObject()
    {
        return playerView.GetInventoryObject();
    }
}

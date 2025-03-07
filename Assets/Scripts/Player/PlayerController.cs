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
    private ShopService shopService;

    private int quantity;
    public PlayerController(PlayerView _playerView, ItemView _itemView,ItemService _itemService,ShopService _shopService)
    {
        playerView = _playerView;
        playerModel = new PlayerModel();
        itemView = _itemView;
        itemService = _itemService;
        shopService = _shopService;
        playerView.SetPlayerController(this);
        playerModel.SetController(this);
        PopulateList();
        quantity = 0;
        EventService.Instance.OnBuyEvent.AddListener(BuyItem);
        EventService.Instance.OnConfirmButtonClickedEvent.AddListener(ProcessConfirmButton);
        EventService.Instance.OnPlusButtonClickedEvent.AddListener(ProcessPlusButton);
        EventService.Instance.OnMinusButtonClickedEvent.AddListener(ProcessMinusButton);
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

    public void ProcessPlusButton()
    {
        quantity++;
    }

    public void ProcessMinusButton()
    {
        quantity--;
    }
    
    public void ProcessConfirmButton(ItemModel _itemModel)
    {
        for (int i = 0; i < playerModel.PlayerItemList.Count; i++)
        {
            if (playerModel.PlayerItemList[i].GetItemName() == _itemModel.GetItemName() && playerModel.PlayerItemList[i].GetItem()._inPlayerQuantity <= playerModel.PlayerItemList[i].GetItem()._fixedQuantity)
            {
                playerModel.PlayerItemList[i].GetItem()._inPlayerQuantity += shopService.GetSelectionQuantity();
            }
        }
    }

    public void SetSelectionQuantity(int _quantity)
    {
        quantity = _quantity;
    }
    public int GetSelectionQuantity()
    {
        return quantity;
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

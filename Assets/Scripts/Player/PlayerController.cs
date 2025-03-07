using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using static UnityEngine.Object;
using UnityEngine;

public class PlayerController 
{
    private PlayerView playerView;
    private PlayerModel playerModel;
    private ItemView itemView;
    private ItemService itemService;
    private ShopService shopService;
    private UIService uiService;

    private int quantity;
    public PlayerController(PlayerView _playerView, ItemView _itemView,ItemService _itemService,ShopService _shopService,UIService _uiService)
    {
        playerView = _playerView;
        playerModel = new PlayerModel();
        itemView = _itemView;
        itemService = _itemService;
        shopService = _shopService;
        uiService = _uiService;
        playerView.SetPlayerController(this);
        playerModel.SetController(this);
        PopulateList();
        quantity = 0;
        IncreaseTotalBerries(500);
        EventService.Instance.OnConfirmBuyButtonClickedEvent.AddListener(BuyItem);
        EventService.Instance.OnConfirmBuyButtonClickedEvent.AddListener(ProcessConfirmBuyButton);
        EventService.Instance.OnPlusButtonClickedEvent.AddListener(ProcessPlusButton);
        EventService.Instance.OnMinusButtonClickedEvent.AddListener(ProcessMinusButton);
        EventService.Instance.OnConfirmSellButtonClickedEvent.AddListener(ProcessConfirmSellButton);
        EventService.Instance.OnConfirmSellButtonClickedEvent.AddListener(SellItem);
        EventService.Instance.OnButtonRandomClickedEvent.AddListener(GetRandomItems);

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

    public void SellItem(ItemModel item)
    {
        for (int i = 0; i < playerModel.PlayerItemList.Count; i++)
        {
            if (playerModel.PlayerItemList[i].GetItemName() == item.GetItemName() && 
                playerModel.PlayerItemList[i].GetItem()._inPlayerQuantity == 0
                )
            {
                playerModel.PlayerItemList[i].HideItem();
            } else if (playerModel.PlayerItemList[i].GetItemName() == item.GetItemName())
            {
                
            }
        }
    }

    public void OnSellButtonClicked(ItemModel item)
    {
        int temp1 = quantity * item.GetItemPrice();
        int temp2 = quantity * item.GetItemWeight();
        DecreaseTotalWeight(temp2);
        IncreaseTotalBerries(temp1);
    }

    public void OnBuyButtonClicked(ItemModel item)
    {
        int temp1 = shopService.GetSelectionQuantity() * item.GetItemPrice();
        int temp2 = shopService.GetSelectionQuantity() * item.GetItemWeight();
        DecreaseTotalBerries(temp1);
        IncreaseTotalWeight(temp2);
    }
    
    public void ProcessPlusButton()
    {
            quantity++;
    }

    public void ProcessMinusButton()
    {
            quantity--;
    }
    
    public void ProcessConfirmBuyButton(ItemModel _itemModel)
    {
        
        for (int i = 0; i < playerModel.PlayerItemList.Count; i++)
        {
            if (playerModel.PlayerItemList[i].GetItemName() == _itemModel.GetItemName() && 
                playerModel.PlayerItemList[i].GetItem()._inPlayerQuantity < 
                playerModel.PlayerItemList[i].GetItem()._fixedQuantity
                )
            {
                playerModel.PlayerItemList[i].GetItem()._inPlayerQuantity += shopService.GetSelectionQuantity();
                OnBuyButtonClicked(_itemModel);
            }
            else 
            if (playerModel.PlayerItemList[i].GetItemName() == _itemModel.GetItemName() &&
                      playerModel.PlayerItemList[i].GetItem()._inPlayerQuantity >
                      playerModel.PlayerItemList[i].GetItem()._fixedQuantity 
                      )
            {
                uiService.GiveErrorMessage();
            }
        }
    }

    public void ProcessConfirmSellButton(ItemModel _itemModel)
    {
        
        for (int i = 0; i < playerModel.PlayerItemList.Count; i++)
        {
            if (playerModel.PlayerItemList[i].GetItemName() == _itemModel.GetItemName() && 
                quantity <= playerModel.PlayerItemList[i].GetItem()._inPlayerQuantity
               )
            {
                playerModel.PlayerItemList[i].GetItem()._inPlayerQuantity -= quantity;
                OnSellButtonClicked(_itemModel);
            }
            else 
            if (playerModel.PlayerItemList[i].GetItemName() == _itemModel.GetItemName() &&
                quantity >  playerModel.PlayerItemList[i].GetItem()._inPlayerQuantity
               )
            {
                uiService.GiveErrorMessage();
            }
        }
    }

    private void GetRandomItems()
    {
        int numberOfItemsToSelect = Random.Range(1, 6);

        for (int i = 0; i < numberOfItemsToSelect; i++)
        {
                int randomIndex = Random.Range(0, playerModel.PlayerItemList.Count);
                ItemController selectedItem = playerModel.PlayerItemList[randomIndex];
                
                selectedItem.GetItem()._inPlayerQuantity = Random.Range(1,selectedItem.GetItem()._fixedQuantity);
                selectedItem.GetItem()._quantity = 0;
                int tempWeight = selectedItem.GetItem()._inPlayerQuantity * selectedItem.GetItem()._weight;
                if (GetMaxWeight() >= GetTotalWeight() )
                {
                    IncreaseTotalWeight(tempWeight);
                    selectedItem.ShowItem();
                }
                else
                {
                    break;
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

    public int GetTotalBerries()
    {
        return playerModel.GetTotalBerries();
    }

    public void IncreaseTotalBerries(int _totalBerries)
    {
        playerModel.IncreaseTotalBerries(_totalBerries);
    }

    public void DecreaseTotalBerries(int _totalBerries)
    {
        playerModel.DecreaseTotalBerries(_totalBerries);
    }

    public int GetTotalWeight()
    {
        return playerModel.GetTotalWeight();
    }

    public int GetMaxWeight()
    {
        return playerModel.GetMaxWeight();
    }

    public void DecreaseTotalWeight(int _totalWeight)
    {
        playerModel.DecreaseTotalWeight(_totalWeight);
    }

    public void IncreaseTotalWeight(int _totalWeight)
    {
        playerModel.IncreaseTotalWeight(_totalWeight);
    }
    public InventoryScriptableObject GetInventoryObject()
    {
        return playerView.GetInventoryObject();
    }

    
}

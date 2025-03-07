using System.Collections.Generic;
using UnityEngine;

public class ShopController 
{
    private ShopView shopView;
    private ShopModel shopModel;
    private ItemView itemView;
    private ItemService itemService;

    public ShopController(ShopView _shopView, ItemView _itemView,ItemService _itemService)
    {
        shopView = _shopView;
        shopModel = new ShopModel();
        itemView = _itemView;
        itemService = _itemService;
        shopView.SetShopController(this);
        PopulateList();
        PopulateShop();
        EventService.Instance.OnFilterButtonClickedEvent.AddListener(FilterShop);
    }

    public void PopulateShop()
    {
        for (int i = 0; i < shopModel.ShopItemList.Count; i++)
        {
            shopModel.ShopItemList[i].ShowItem();
        }
    }

    public void PopulateList()
    {
        for (int i = 0; i < GetShopScriptableObject().items.Count; i++)
        {
            ItemController itemController = itemService.CreateItem(GetShopScriptableObject().items[i],itemView,GetShopTransform(),ItemParentType.SHOP);
            shopModel.AddItem(itemController);
        }
    }

    public void FilterShop(ItemTypes _itemType)
    {
        for (int i = 0; i < shopModel.ShopItemList.Count; i++)
        {
            if (shopModel.ShopItemList[i].GetItemType() == _itemType)
            {
                shopModel.ShopItemList[i].ShowItem();
            }
            else
            {
                shopModel.ShopItemList[i].HideItem();
            }
        }
    }
    
    public Transform GetShopTransform()
    {
        return shopView.GetShopTransform();
    }

    public InventoryScriptableObject GetShopScriptableObject()
    {
        return shopView.GetShopInventoryObject();
    }
}

using UnityEngine;

using Inventory.Event;
using Inventory.Item;
using Inventory.Player;

using Inventory.UI;

namespace Inventory.Shop
{
    public class ShopController
    {
        private ShopView shopView;
        private ShopModel shopModel;
        private ItemView itemView;
        private ItemService itemService;
        private PlayerService playerService;
        private UIService uiService;

        private int quantity;

        public ShopController(ShopView _shopView, ItemView _itemView, ItemService _itemService,
            PlayerService _playerService, UIService _uiService)
        {
            shopModel = new ShopModel();
            shopView = _shopView;
            itemView = _itemView;
            itemService = _itemService;
            playerService = _playerService;
            uiService = _uiService;
            
            shopView.SetShopController(this);
            
            Reset();
            eventServices();
        }

        public void eventServices()
        {
            EventService.Instance.OnFilterButtonClickedEvent.AddListener(FilterShop);
            EventService.Instance.OnConfirmBuyButtonClickedEvent.AddListener(ProcessConfirmBuyButton);
            EventService.Instance.OnPlusButtonClickedEvent.AddListener(ProcessPlusButton);
            EventService.Instance.OnMinusButtonClickedEvent.AddListener(ProcessMinusButton);
            EventService.Instance.OnConfirmSellButtonClickedEvent.AddListener(ProcessConfirmSellButton);
        }

        public void Reset()
        {
            PopulateList();
            PopulateShop();
            quantity = 0;
        }
        ~ShopController()
        {
            EventService.Instance.OnFilterButtonClickedEvent.RemoveListener(FilterShop);
            EventService.Instance.OnConfirmBuyButtonClickedEvent.RemoveListener(ProcessConfirmBuyButton);
            EventService.Instance.OnPlusButtonClickedEvent.RemoveListener(ProcessPlusButton);
            EventService.Instance.OnMinusButtonClickedEvent.RemoveListener(ProcessMinusButton);
            EventService.Instance.OnConfirmSellButtonClickedEvent.RemoveListener(ProcessConfirmSellButton);
        }
        private void PopulateShop()
        {
            for (int i = 0; i < shopModel.ShopItemList.Count; i++)
            {
                shopModel.ShopItemList[i].ShowItem();
            }
        }

        private void PopulateList()
        {
            for (int i = 0; i < GetShopScriptableObject().items.Count; i++)
            {
                ItemController itemController = itemService.CreateItem(GetShopScriptableObject().items[i], itemView,
                    GetShopTransform(), ItemParentType.SHOP);
                shopModel.AddItem(itemController);
            }
        }

        private void FilterShop(ItemTypes _itemType)
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

        private void ProcessPlusButton()
        {
            if (quantity < 10)
            {
                quantity++;
            }
        }

        private void ProcessMinusButton()
        {
            if (quantity > 0)
            {
                quantity--;
            }
        }

        private void ProcessConfirmBuyButton(ItemModel _itemModel)
        {
            for (int i = 0; i < shopModel.ShopItemList.Count; i++)
            {
                if (shopModel.ShopItemList[i].GetItemName() == _itemModel.GetItemName() &&
                    quantity <= shopModel.ShopItemList[i].GetItem()._quantity
                   )
                {
                    shopModel.ShopItemList[i].GetItem()._quantity -= quantity;
                }
                else if (shopModel.ShopItemList[i].GetItemName() == _itemModel.GetItemName() &&
                         quantity > shopModel.ShopItemList[i].GetItem()._quantity
                        )
                {
                    uiService.GiveErrorMessage();
                }
            }
        }

        private void ProcessConfirmSellButton(ItemModel _itemModel)
        {
            for (int i = 0; i < shopModel.ShopItemList.Count; i++)
            {
                if (shopModel.ShopItemList[i].GetItemName() == _itemModel.GetItemName() &&
                    shopModel.ShopItemList[i].GetItem()._quantity <= shopModel.ShopItemList[i].GetItem()._fixedQuantity
                   )
                {
                    shopModel.ShopItemList[i].GetItem()._quantity += playerService.GetSelectionQuantity();
                }
                else if (shopModel.ShopItemList[i].GetItemName() == _itemModel.GetItemName() &&
                         shopModel.ShopItemList[i].GetItem()._quantity >
                         shopModel.ShopItemList[i].GetItem()._fixedQuantity
                        )
                {
                    uiService.GiveErrorMessage();
                }
            }
        }

        public int GetSelectedQuantity()
        {
            return quantity;
        }

        public void SetSelectionQuantity(int _quantity)
        {
            this.quantity = _quantity;
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
}

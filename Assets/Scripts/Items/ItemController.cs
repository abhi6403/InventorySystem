using UnityEngine;

using Inventory.Event;

namespace Inventory.Item
{
    public class ItemController
    {
        private ItemModel itemModel;
        private ItemView itemView;

        private GameObject itemDetails;
        private GameObject confirmationPannel;

        public ItemController(ItemsScriptableObject itemData, ItemView _itemView, Transform _getParentTransform,
            ItemParentType _itemParentType)
        {
            itemModel = new ItemModel(itemData, _getParentTransform, _itemParentType);
            itemView = GameObject.Instantiate(_itemView, GetParentTransform());
            itemView.Initialize(GetItemImage(), GetItemPrice());
            itemModel.SetItemController(this);
            itemView.SetItemController(this);
        }

        public void ShowItemDetails()
        {
            EventService.Instance.OnItemButtonClickedEvent.InvokeEvent(itemModel);
        }

        public Sprite GetItemImage()
        {
            return itemModel.GetItemImage();
        }

        public string GetItemName()
        {
            return itemModel.GetItemName();
        }

        public string GetItemDescription()
        {
            return itemModel.GetItemDescription();
        }

        public int GetItemPrice()
        {
            return itemModel.GetItemPrice();
        }

        public int GetItemWeight()
        {
            return itemModel.GetItemWeight();
        }

        public Transform GetParentTransform()
        {
            return itemModel.GetParentTransform();
        }

        public GameObject GetItemDetailsUIGameObject()
        {
            return itemModel.GetItemDetailsUIGameObject();
        }

        public ItemsScriptableObject GetItem()
        {
            return itemModel.GetItem();
        }

        public ItemParentType GetItemParentType()
        {
            return itemModel.GetItemParentType();
        }

        public ItemTypes GetItemType()
        {
            return itemModel.GetItemType();
        }

        public void ShowItem()
        {
            itemView.ShowItem();
        }

        public void HideItem()
        {
            itemView.HideItem();
        }

        public int GetQantityOfPlayer()
        {
            return itemModel.GetQuantityOfPlayer();
        }

        public int GetQuantityOfShop()
        {
            return itemModel.GetQuantityOfShop();
        }
    }
}

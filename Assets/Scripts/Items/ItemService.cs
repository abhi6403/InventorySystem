using UnityEngine;

namespace Inventory.Item
{


    public class ItemService
    {
        private ItemController itemController;
        private ItemsScriptableObject itemsData;

        public ItemController CreateItem(ItemsScriptableObject itemData, ItemView _itemView,
            Transform _getParentTransform, ItemParentType _itemParentType)
        {
            this.itemsData = itemData;
            return new ItemController(itemsData, _itemView, _getParentTransform, _itemParentType);

        }

        public ItemController GetItemController()
        {
            return itemController;
        }
    }
}

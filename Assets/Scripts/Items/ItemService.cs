using UnityEngine;

public class ItemService
{
    private ItemController itemController;
    public ItemService(ItemView _itemView,ItemsScriptableObject _itemScriptableObejct,Transform _getParentTransform,ItemParentType _itemParentType)
    {
        itemController = new ItemController(_itemView, _itemScriptableObejct, _getParentTransform,_itemParentType);
    }

    public ItemController GetItemController()
    {
        return itemController;
    }
}

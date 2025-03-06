using UnityEngine;

public class ItemService
{
    private ItemController itemController;
    public ItemService(ItemView _itemView,ItemsScriptableObject _itemScriptableObejct,Transform _getParentTransform)
    {
        itemController = new ItemController(_itemView, _itemScriptableObejct, _getParentTransform);
    }

    public ItemController GetItemController()
    {
        return itemController;
    }
}

using UnityEngine;

public class ItemService
{
    private ItemController itemController;
    private ItemsScriptableObject itemsData;
    public void Initialize(ItemView _itemView,ItemsScriptableObject _itemScriptableObejct,Transform _getParentTransform,ItemParentType _itemParentType)
    {
        //ItemModel itemModel = new ItemModel(_itemScriptableObejct,_getParentTransform,_itemParentType);
        //itemController = new ItemController(_itemView, itemModel);
    }

    public ItemController CreateItem(ItemsScriptableObject itemData,ItemView _itemView,Transform _getParentTransform,ItemParentType _itemParentType)
    {
        this.itemsData = itemData;
        return new ItemController(itemData, _itemView,_getParentTransform,_itemParentType);

    }
    public ItemController GetItemController()
    {
        return itemController;
    }
}

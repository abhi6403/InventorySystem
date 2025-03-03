using UnityEngine;

public class ItemController
{
    private ItemModel itemModel;
    private ItemView itemView;

    public ItemController(ItemModel _itemModel, ItemView _itemView)
    {
        itemModel = _itemModel;
        itemView = GameObject.Instantiate(_itemView,GetParentTransform());
        itemView.Initialize(GetItemImage(),GetItemPrice());
        itemModel.SetItemController(this);
        itemView.SetItemController(this);
    }

    public void ShowItemDetails()
    {
        itemView.GetItemDetailsObject().InitializeItemDetailsUI(GetItemImage(),GetItemName(),GetItemDescription(),GetItemPrice(),GetItemQuantity(),GetItemWeight());
        ItemDetailsUI itemDetailsUI = GameObject.Instantiate(itemView.GetItemDetailsObject(),itemView.GetItemDetailsObjectTransform());
    }
    
    public Transform GetParentTransform()
    {
        return itemModel.GetParentTransform();
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

    public int GetItemQuantity()
    {
        return itemModel.GetItemQuantity();
    }

    public int GetItemWeight()
    {
        return itemModel.GetItemWeight();
    }
}

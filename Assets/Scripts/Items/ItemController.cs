using Unity.VisualScripting;
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
        itemView.InitializeItemDetailsUI(GetItemImage(),GetItemName(),GetItemDescription(),GetItemPrice(),GetItemQuantity(),GetItemWeight());
        //itemView.GetItemDetails().transform.position = itemView.GetItemDetailsObjectTransform().position;
        //itemView.GetItemDetails().SetActive(true);
        GameObject detailsObject = GameObject.Instantiate(itemView.GetItemDetails(),itemView.GetItemDetailsObjectTransform());
        detailsObject.SetActive(true);
        itemModel.SetItemDetailsUIGameObject(detailsObject);
    }

    public void CloseItemDetails()
    {
        GameObject.Destroy(itemModel.GetItemDetailsUIGameObject());
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

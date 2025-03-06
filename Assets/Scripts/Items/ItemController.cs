using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemController
{
    private ItemModel itemModel;
    private ItemView itemView;

    public ItemController(ItemView _itemView, ItemsScriptableObject _itemsScriptableObject,Transform _getParentTransform)
    {
        itemModel = new ItemModel(_itemsScriptableObject, _getParentTransform);
        itemView = GameObject.Instantiate(_itemView,_getParentTransform);
        itemView.Initialize(GetItemImage(),GetItemPrice());
        itemModel.SetItemController(this);
        itemView.SetItemController(this);
    }

    public void ShowItemDetails()
    {
        itemView.InitializeItemDetails(itemModel.GetItem());
        GameObject detailsObject = GameObject.Instantiate(itemView.GetItemDetails(),itemView.GetItemDetailsObjectTransform());
        detailsObject.SetActive(true);
        itemModel.SetItemDetailsUIGameObject(detailsObject);
        TextMeshProUGUI textMeshPro = detailsObject.transform.Find("ItemQuantity").GetComponent<TextMeshProUGUI>();
        SetItemQuantityText(textMeshPro);
    }

    public void SetItemQuantityText(TextMeshProUGUI _quantityText)
    {
        itemModel.SetCurrentQuantityText(_quantityText);
    }

    public void ProcessPlusButtonClicked()
    {
        itemModel.IncreaseQuantity(1);
        itemModel.GetCurrentQuantityText().text = itemModel.GetCurrentQuantity().ToString();
    }

    public void ProcessMinusButtonClicked()
    {
        itemModel.DecreaseQuantity(1);
        itemModel.GetCurrentQuantityText().text = itemModel.GetCurrentQuantity().ToString();
    }

    public void ProcessBuyButtonClicked()
    {
        EventService.Instance.OnBuyButtonClickedEvent.InvokeEvent(itemModel.GetItem());
    }

    public void DoafterBuyButtonClicked()
    {
        itemModel.SetCurrentQuantity(0);
        itemView.GetAvailableItemQuantityText().gameObject.SetActive(false);
        itemView.GetItemAvailableInPlayer().gameObject.SetActive(true);
        itemView.GetItemAvailableInPlayer().text = itemModel.GetCurrentQuantityInPlayer().ToString();
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

    public int GetItemAvailableQuantity()
    {
        return itemModel.GetItemAvailableQuantity();
    }

    public int GetItemWeight()
    {
        return itemModel.GetItemWeight();
    }
}

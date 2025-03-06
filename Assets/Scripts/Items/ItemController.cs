using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemController
{
    private ItemModel itemModel;
    private ItemView itemView;

    private GameObject itemDetails;
    private GameObject confirmationPannel;

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
        //GameObject detailsObject = GameObject.Instantiate(itemView.GetItemDetails(),itemView.GetItemDetailsObjectTransform());
        itemDetails = GameObject.Instantiate(itemView.GetItemDetails(),itemView.GetItemDetailsObjectTransform());
        itemDetails.SetActive(true);
        //detailsObject.SetActive(true);
        itemModel.SetItemDetailsUIGameObject(itemDetails);
        TextMeshProUGUI textMeshPro = itemDetails.transform.Find("ItemQuantity").GetComponent<TextMeshProUGUI>();
        SetItemQuantityText(textMeshPro);
        TextMeshProUGUI textMeshPro1 = itemDetails.transform.Find("ItemAvailableQuantity").GetComponent<TextMeshProUGUI>();
        itemModel.SetAvailableQuantityText(textMeshPro1);
    }

    public void SetItemQuantityText(TextMeshProUGUI _quantityText)
    {
        itemModel.SetCurrentQuantityText(_quantityText);
    }

    public void ProcessPlusButtonClicked()
    {
        itemModel.IncreaseQuantity(1);
        itemModel.GetCurrentQuantityText().text = itemModel.GetCurrentQuantity().ToString();
        itemModel.GetAvailableQuantityText().text = "Available - " + itemModel.GetItemAvailableQuantity();
    }

    public void ProcessMinusButtonClicked()
    {
        itemModel.DecreaseQuantity(1);
        itemModel.GetCurrentQuantityText().text = itemModel.GetCurrentQuantity().ToString();
        itemModel.GetAvailableQuantityText().text = "Available - " + itemModel.GetItemAvailableQuantity();
    }

    public void ProcessBuyButtonClicked()
    {
        confirmationPannel = GameObject.Instantiate(itemView.confirmationPannel,itemView.GetItemDetailsObjectTransform());
        confirmationPannel.SetActive(true);
    }

    public void processConfirmButtonClicked()
    {
        EventService.Instance.OnBuyButtonClickedEvent.InvokeEvent(itemModel.GetItem());
        confirmationPannel.SetActive(false);
        itemDetails.SetActive(false);
    }

    public void processCancelButtonClicked()
    {
        itemView.confirmationPannel.gameObject.SetActive(false);
        confirmationPannel.SetActive(false);
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

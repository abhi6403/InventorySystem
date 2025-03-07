using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemController
{
    private ItemModel itemModel;
    private ItemView itemView;

    private GameObject itemDetails;
    private GameObject confirmationPannel;

    public ItemController(ItemView _itemView, ItemsScriptableObject _itemsScriptableObject,Transform _getParentTransform,ItemParentType _itemParentType)
    {
        itemModel = new ItemModel(_itemsScriptableObject, _getParentTransform, _itemParentType);
        itemView = GameObject.Instantiate(_itemView,_getParentTransform);
        itemView.Initialize(GetItemImage(),GetItemPrice());
        itemModel.SetItemController(this);
        itemView.SetItemController(this);
    }

    public void ShowItemDetails()
    {
        if (itemModel.GetItemParentType() == ItemParentType.SHOP)
        {
            itemView.InitializeItemDetails(itemModel.GetItem());
            itemDetails = GameObject.Instantiate(itemView.GetItemDetails(),itemView.GetItemDetailsObjectTransform());
            itemDetails.SetActive(true);
            itemModel.SetItemDetailsUIGameObject(itemDetails);
            SetCurrentQuantityTextInShop();
            SetAvailableQuantityTextInShop();
        }else if (itemModel.GetItemParentType() == ItemParentType.PLAYER)
        {
            itemDetails = itemView.GetItemDetails();
            itemModel.SetItemDetailsUIGameObject(itemDetails);
            SetCurrentQuantityTextInPlayer();
            SetAvailableQuantityTextInPlayer();
            itemView.InitializePlayerItemDetails(itemModel.GetItem());
            itemDetails = GameObject.Instantiate(itemView.GetItemDetails(),itemView.GetItemDetailsObjectTransform());
            itemDetails.SetActive(true);
        }
        
    }

    public void SetCurrentQuantityTextInShop()
    {
        itemModel.SetCurrentQuantityTextInShop();
    }

    public void SetCurrentQuantityTextInPlayer()
    {
        itemModel.SetCurrentQuantityTextInPlayer();
    }

    public void SetAvailableQuantityTextInShop()
    {
        itemModel.SetAvailableQuantityTextInShop();
    }

    public void SetAvailableQuantityTextInPlayer()
    {
       itemModel.SetAvailableQuantityTextInPlayer();
    }
    public void ProcessPlusButtonClicked()
    {
        
    }

    public void ProcessMinusButtonClicked()
    {
       
    }

    public void ProcessBuyButtonClicked()
    {
        confirmationPannel = GameObject.Instantiate(GetConfirmationPannel(),itemView.GetItemDetailsObjectTransform());
        confirmationPannel.SetActive(true);
    }

    public void processConfirmButtonClicked()
    {
        EventService.Instance.OnBuyButtonClickedEvent.InvokeEvent(itemModel.GetItem());
        itemModel.SetCurrentQuantityInShop(0);
        GameObject.Destroy(itemDetails);
        GameObject.Destroy(confirmationPannel);
    }

    public void processCancelButtonClicked()
    {
        GameObject.Destroy(confirmationPannel);
    }
    
    public void CloseItemDetails()
    {
        GameObject.Destroy(itemDetails);
        GameObject.Destroy(confirmationPannel);
    }

    public GameObject GetConfirmationPannel()
    {
        return itemView.GetConfirmationPannel();
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
    public int GetItemAvailableQuantityInShop()
    {
        return itemModel.GetItemAvailableQuantityInShop();
    }
    public int GetItemAvailableQuantityInPlayer()
    {
        return itemModel.GetAvailableQuantityInPlayer();
    }
    public int GetItemWeight()
    {
        return itemModel.GetItemWeight();
    }
    public int GetCurrentQuantityInShop()
    {
        return itemModel.GetCurrentQuantityInShop();
    }
    public int GetCurrentQuantityInPlayer()
    {
        return itemModel.GetCurrentQuantityInPlayer();
    }
    public Transform GetParentTransform()
    {
        return itemModel.GetParentTransform();
    }
    public GameObject GetItemDetailsUIGameObject()
    {
        return itemModel.GetItemDetailsUIGameObject();
    }
    public TextMeshProUGUI GetCurrentQuantityTextInShop()
    {
        return itemModel.GetCurrentQuantityTextInShop();
    }

    public TextMeshProUGUI GetCurrentQuantityTextInPlayer()
    {
        return itemModel.GetCurrentQuantityTextInPlayer();
    }
    public TextMeshProUGUI GetAvailableQuantityInShopText()
    {
        return itemModel.GetAvailableQuantityInShopText();
    }
    public TextMeshProUGUI GetAvailableQuantityInPlayerText()
    {
        return itemModel.GetAvailableQuantityInPlayerText();
    }
    public ItemsScriptableObject GetItem()
    {
        return itemModel.GetItem();
    }
    public ItemParentType GetItemParentType()
    {
        return itemModel.GetItemParentType();
    }
}

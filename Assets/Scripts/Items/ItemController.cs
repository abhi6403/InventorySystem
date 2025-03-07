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
        if (GetItemParentType() == ItemParentType.SHOP)
        {
            itemView.InitializeItemDetails(itemModel.GetItem());
            itemDetails = GameObject.Instantiate(itemView.GetItemDetails(),itemView.GetItemDetailsObjectTransform());
            itemDetails.SetActive(true);
            SetItemDetailsUIGameObject(itemDetails);
            SetCurrentQuantityTextInShop();
            SetAvailableQuantityTextInShop();
        }else if (GetItemParentType() == ItemParentType.PLAYER)
        {
            itemView.InitializePlayerItemDetails(itemModel.GetItem());
            itemDetails = GameObject.Instantiate(itemView.GetItemDetails(),itemView.GetItemDetailsObjectTransform());
            itemDetails.SetActive(true);
            SetItemDetailsUIGameObject(itemDetails);
            SetCurrentQuantityTextInPlayer();
            SetAvailableQuantityTextInPlayer();
        }
        
    }

    private void SetItemDetailsUIGameObject(GameObject gameObject)
    {
        itemModel.SetItemDetailsUIGameObject(gameObject);
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
        if (GetItemParentType() == ItemParentType.SHOP && GetCurrentQuantityInShop() < GetItem()._quantity)
        {
            IncreaseCurrentQuantityInShop(1);
            GetCurrentQuantityTextInShop().text = GetCurrentQuantityInShop().ToString();
        }else if (GetItemParentType() == ItemParentType.PLAYER && GetCurrentQuantityInPlayer() < GetItem()._inPlayerQuantity)
        {
            Debug.Log("Getting In");
            IncreaseCurrentQuantityInPlayer(1);
            GetCurrentQuantityTextInPlayer().text = GetCurrentQuantityInPlayer().ToString();
        }
    }

    public void ProcessMinusButtonClicked()
    {
        if (GetItemParentType() == ItemParentType.SHOP && GetCurrentQuantityInShop() > GetItem()._quantity)
        {
            DecreaseCurrentQuantityInShop(1);
            GetCurrentQuantityTextInShop().text = GetCurrentQuantityInShop().ToString();
        }else if (GetItemParentType() == ItemParentType.PLAYER && GetCurrentQuantityInPlayer() > GetItem()._quantity)
        {
            DecreaseCurrentQuantityInPlayer(1);
            GetCurrentQuantityTextInPlayer().text = GetCurrentQuantityInPlayer().ToString();
        }
    }

    public void ProcessBuyButtonClicked()
    {
        confirmationPannel = GameObject.Instantiate(GetConfirmationPannel(),itemView.GetItemDetailsObjectTransform());
        confirmationPannel.SetActive(true);
    }

    public void processConfirmButtonClicked()
    {
        if (GetItemAvailableQuantityInShop() > 0)
        {
            EventService.Instance.OnBuyButtonClickedEvent.InvokeEvent(itemModel.GetItem());
            IncreaseAvailableQuantityInPlayer(GetCurrentQuantityInShop());
            DecreaseAvailableQuantityInShop(GetCurrentQuantityInShop());
            SetCurrentQuantityInShop();
            GameObject.Destroy(itemDetails);
            GameObject.Destroy(confirmationPannel);
        }
        else
        {
            Debug.Log("Not enough available quantity");
        }
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

    public void SetCurrentQuantityInShop()
    {
        itemModel.SetCurrentQuantityInShop();
    }
    public void IncreaseAvailableQuantityInShop(int _quantity)
    {
        itemModel.IncreaseAvailableQuantityInShop(_quantity);
    }
    public void DecreaseAvailableQuantityInShop(int _quantity)
    {
        itemModel.DecreaseAvailableQuantityInShop(_quantity);
    }
    public void IncreaseAvailableQuantityInPlayer(int _quantity)
    {
        itemModel.IncreaseAvailableQuantityInPlayer(_quantity);
    }
    
    public void DecreaseAvailableQuantityInPlayer(int _quantity)
    {
        itemModel.DecreaseAvailableQuantityInPlayer(_quantity);
    }
    public void IncreaseCurrentQuantityInShop(int _quantity)
    {
        itemModel.IncreaseCurrentQuantityInShop(_quantity);
    }
    public void DecreaseCurrentQuantityInShop(int _quantity)
    {
        itemModel.DecreaseCurrentQuantityInShop(_quantity);
    }
    public void IncreaseCurrentQuantityInPlayer(int _quantity)
    {
        itemModel.IncreaseCurrentQuantityInPlayer(_quantity);
    }

    public void DecreaseCurrentQuantityInPlayer(int _quantity)
    {
        itemModel.DecreaseCurrentQuantityInPlayer(_quantity);
    }

    public TextMeshProUGUI GetItemQuantityText()
    {
        return itemView.GetItemQuantityText();
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
    public TextMeshProUGUI GetAvailableQuantityTextInPlayer()
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

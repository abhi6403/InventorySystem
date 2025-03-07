using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    [SerializeField]private GameObject itemDetailsPannel;
    [SerializeField]private GameObject confirmationPannel;
    
    [SerializeField]private Image itemDetailsImage;
    [SerializeField]private TextMeshProUGUI itemPrice;
    [SerializeField]private TextMeshProUGUI itemName;
    [SerializeField]private TextMeshProUGUI itemDescription;
    [SerializeField]private TextMeshProUGUI itemBerries;
    [SerializeField]private TextMeshProUGUI itemQuantity;
    [SerializeField]private TextMeshProUGUI itemAvailableQuantity;
    [SerializeField]private TextMeshProUGUI itemAvailableInPlayer;
    [SerializeField]private TextMeshProUGUI itemWeight;
    
    [SerializeField]private Button plusButton;
    [SerializeField]private Button minusButton;
    [SerializeField]private Button closeButton;
    [SerializeField]private Button buyButton;
    [SerializeField]private Button SellButton;
    
    private ShopService shopService;
    private PlayerService playerService;
    
    private ItemModel _itemModel;

    public void Initialize(ShopService _shopService,PlayerService _playerService)
    {
        shopService = _shopService;
        playerService = _playerService;
        EventService.Instance.OnItemButtonClickedEvent.AddListener(ShowItemDetails);
    }
    
    private void ShowItemDetails(ItemModel itemData)
    {
        _itemModel = itemData;

        if (itemData.GetItemParentType() == ItemParentType.SHOP)
        {
            itemDetailsImage.sprite = _itemModel.GetItemImage();
            itemName.text = _itemModel.GetItemName();
            itemDescription.text = _itemModel.GetItemDescription();
            itemBerries.text = "Berries - " + _itemModel.GetItemPrice();
            itemAvailableQuantity.text = "Available - " + _itemModel.GetQuantityOfShop();
            itemQuantity.text = shopService.GetSelectionQuantity().ToString();
            itemWeight.text = "Weight - " + _itemModel.GetItemWeight();
            itemAvailableQuantity.gameObject.SetActive(true);
            itemAvailableInPlayer.gameObject.SetActive(false);
        }else if (itemData.GetItemParentType() == ItemParentType.PLAYER)
        {
            itemDetailsImage.sprite = _itemModel.GetItemImage();
            itemName.text = _itemModel.GetItemName(); 
            itemDescription.text = _itemModel.GetItemDescription();
            itemBerries.text = "Berries - " + _itemModel.GetItemPrice();
            itemAvailableInPlayer.text = "Available - " + _itemModel.GetQantityOfPlayer();
            itemQuantity.text = playerService.GetSelectionQuantity().ToString();
            itemWeight.text = "Weight - " + _itemModel.GetItemWeight();
            itemAvailableInPlayer.gameObject.SetActive(true);
            itemAvailableQuantity.gameObject.SetActive(false);
        }
        itemDetailsPannel.SetActive(true);
    }

    public void OnPlusButtonClicked()
    {
        EventService.Instance.OnPlusButtonClickedEvent.InvokeEvent();
        itemQuantity.text = shopService.GetSelectionQuantity().ToString();
    }

    public void OnMinusButtonClicked()
    {
        EventService.Instance.OnMinusButtonClickedEvent.InvokeEvent();
        itemQuantity.text = shopService.GetSelectionQuantity().ToString();
    }

    public void OnConfirmButtonClicked()
    {
        EventService.Instance.OnConfirmBuyButtonClickedEvent.InvokeEvent(_itemModel);
        EventService.Instance.OnBuyEvent.InvokeEvent(_itemModel);
        itemDetailsPannel.SetActive(false);
        confirmationPannel.SetActive(false);
        shopService.SetSelectionQuantity(0);
        playerService.SetSelectionQuantity(0);
    }

    public void OnBuyButtonClicked()
    {
        confirmationPannel.SetActive(true);
    }

    public void OnSellButtonClicked()
    {
        confirmationPannel.SetActive(false);
    }

    public void OnCancelButtonClicked()
    {
        confirmationPannel.SetActive(false);
    }
    public void OnCloseButtonClicked()
    {
        itemDetailsPannel.SetActive(false);
        confirmationPannel.SetActive(false);
    }
   public void getAllItemsInShop()
    {
        EventService.Instance.OnButtonAllClickedEvent.InvokeEvent();
    }

    public void getWeaponItems()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.WEAPON);
    }
    public void getFoodItems()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.HEALTH);
    }

    public void getDevilFruits()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.DEVILFRUIT);
    }

    public void getPosters()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.POSTER);
    }
    
    public void getProps()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.PROPS);
    }
    
    public void getPotions()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.POTION);
    }
    
    public void getShipItems()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.SHIPITEMS);
    }
    
    public void getMap()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.MAP);
    }
    
    
}

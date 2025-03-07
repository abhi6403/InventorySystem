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
    
    private ItemModel _itemModel;

    public void Initialize(ShopService _shopService)
    {
        shopService = _shopService;
        EventService.Instance.OnItemButtonClickedEvent.AddListener(ShowItemDetails);
    }
    
    private void ShowItemDetails(ItemModel itemData)
    {
        _itemModel = itemData;

        itemDetailsImage.sprite = itemData.GetItemImage();
        itemName.text = itemData.GetItemName();
        itemDescription.text = itemData.GetItemDescription();
        itemBerries.text = "Berries - " + itemData.GetItemPrice();
        itemAvailableQuantity.text = "Available - " + itemData.GetItemAvailableQuantityInShop();
        itemQuantity.text = _itemModel.GetCurrentQuantityInShop().ToString();
        itemWeight.text = "Weight - " + itemData.GetItemWeight();
        
        itemDetailsPannel.SetActive(true);
    }

    public void OnPlusButtonClicked()
    {
        EventService.Instance.OnPlusButtonClickedEvent.InvokeEvent();
        itemQuantity.text = _itemModel.GetCurrentQuantityInShop().ToString();
    }

    public void OnMinusButtonClicked()
    {
        EventService.Instance.OnMinusButtonClickedEvent.InvokeEvent();
        itemQuantity.text = _itemModel.GetCurrentQuantityInShop().ToString();
    }

    public void OnConfirmButtonClicked()
    {
        EventService.Instance.OnConfirmButtonClickedEvent.InvokeEvent();
        EventService.Instance.OnBuyEvent.InvokeEvent(_itemModel);
        itemDetailsPannel.SetActive(false);
        confirmationPannel.SetActive(false);
        _itemModel.SetCurrentQuantityInShop();
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
        _itemModel.SetCurrentQuantityInShop();
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

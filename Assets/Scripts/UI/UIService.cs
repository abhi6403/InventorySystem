using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Inventory.Event;
using Inventory.Item;
using Inventory.Player;
using Inventory.Shop;

namespace Inventory.UI
{
    public class UIService : MonoBehaviour
 {
    [SerializeField]private GameObject itemDetailsPannel;
    [SerializeField]private GameObject confirmationPannel;
    [SerializeField]private GameObject errorPannel;
    
    [SerializeField]private Image itemDetailsImage;
    [SerializeField]private TextMeshProUGUI itemPrice;
    [SerializeField]private TextMeshProUGUI itemName;
    [SerializeField]private TextMeshProUGUI itemDescription;
    [SerializeField]private TextMeshProUGUI itemBerries;
    [SerializeField]private TextMeshProUGUI itemQuantity;
    [SerializeField]private TextMeshProUGUI itemAvailableQuantity;
    [SerializeField]private TextMeshProUGUI itemAvailableInPlayer;
    [SerializeField]private TextMeshProUGUI itemWeight;
    [SerializeField] private TextMeshProUGUI itemPriceInConfirmPannel;
    [SerializeField] private TextMeshProUGUI itemWeightText;
    
    [SerializeField]private Button plusButton;
    [SerializeField]private Button minusButton;
    [SerializeField]private Button closeButton;
    [SerializeField]private Button buyButton;
    [SerializeField]private Button SellButton;
    [SerializeField]private Button confirmBuyButton;
    [SerializeField]private Button confirmSellButton;
    [SerializeField]private Button randomButton;
    
    private ShopService shopService;
    private PlayerService playerService;
    
    private ItemModel _itemModel;

    public void Initialize(ShopService _shopService,PlayerService _playerService)
    {
        shopService = _shopService;
        playerService = _playerService;
        EventService.Instance.OnItemButtonClickedEvent.AddListener(ShowItemDetails);
        itemBerries.text = playerService.GetTotalBerries().ToString();
        itemWeightText.text = 0 + " / " + playerService.GetMaxWeight();
    }
    
    private void ShowItemDetails(ItemModel itemData)
    {
        _itemModel = itemData;

        if (itemData.GetItemParentType() == ItemParentType.SHOP)
        {
            itemDetailsImage.sprite = _itemModel.GetItemImage();
            itemName.text = _itemModel.GetItemName();
            itemDescription.text = _itemModel.GetItemDescription();
            itemPrice.text = "Berries - " + _itemModel.GetItemPrice();
            itemAvailableQuantity.text = "Available - " + _itemModel.GetQuantityOfShop();
            itemQuantity.text = shopService.GetSelectionQuantity().ToString();
            itemWeight.text = "Weight - " + _itemModel.GetItemWeight();
            itemAvailableQuantity.gameObject.SetActive(true);
            itemAvailableInPlayer.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(true);
            SellButton.gameObject.SetActive(false);
        }else if (itemData.GetItemParentType() == ItemParentType.PLAYER)
        {
            itemDetailsImage.sprite = _itemModel.GetItemImage();
            itemName.text = _itemModel.GetItemName(); 
            itemDescription.text = _itemModel.GetItemDescription();
            itemPrice.text = "Berries - " + _itemModel.GetItemPrice();
            itemAvailableInPlayer.text = "Available - " + _itemModel.GetQuantityOfPlayer();
            itemQuantity.text = playerService.GetSelectionQuantity().ToString();
            itemWeight.text = "Weight - " + _itemModel.GetItemWeight();
            itemAvailableInPlayer.gameObject.SetActive(true);
            itemAvailableQuantity.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(false);
            SellButton.gameObject.SetActive(true);
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

    public void OnConfirmBuyButtonClicked()
    {
        EventService.Instance.OnConfirmBuyButtonClickedEvent.InvokeEvent(_itemModel);
        itemBerries.text = playerService.GetTotalBerries().ToString();
        itemWeightText.text = playerService.GetTotalWeight() + "/" + playerService.GetMaxWeight(); ;
        itemDetailsPannel.SetActive(false);
        confirmationPannel.SetActive(false);
        shopService.SetSelectionQuantity(0);
        playerService.SetSelectionQuantity(0);
    }

    public void OnConfirmSellButtonClicked()
    {
        EventService.Instance.OnConfirmSellButtonClickedEvent.InvokeEvent(_itemModel);
        itemBerries.text = playerService.GetTotalBerries().ToString();
        itemWeightText.text = playerService.GetTotalWeight() + "/" + playerService.GetMaxWeight(); ;
        itemDetailsPannel.SetActive(false);
        confirmationPannel.SetActive(false);
        shopService.SetSelectionQuantity(0);
        playerService.SetSelectionQuantity(0);
    }
    public void OnBuyButtonClicked()
    {
        int temp = shopService.GetSelectionQuantity() * _itemModel.GetItemPrice();
        int temp2 = playerService.GetSelectionQuantity() * _itemModel.GetItemWeight();

        if (playerService.GetTotalBerries() >= temp && temp2 < playerService.GetMaxWeight())
        {
            itemPriceInConfirmPannel.text = temp.ToString();
            confirmationPannel.SetActive(true);
            confirmBuyButton.gameObject.SetActive(true);
            confirmSellButton.gameObject.SetActive(false);
        }
        else
        {
            errorPannel.SetActive(true);
        }
    }

    public void OnSellButtonClicked()
    {
        int temp = playerService.GetSelectionQuantity() * _itemModel.GetItemPrice() - 100;
        
        if (playerService.GetSelectionQuantity() <= _itemModel.GetItem()._inPlayerQuantity)
        {
            itemPriceInConfirmPannel.text = temp.ToString();
            confirmationPannel.SetActive(true);
            confirmBuyButton.gameObject.SetActive(false);
            confirmSellButton.gameObject.SetActive(true);
        }
        else
        {
            errorPannel.SetActive(true);
        }
    }

    public void OnCancelButtonClicked()
    {
        confirmationPannel.SetActive(false);
        errorPannel.SetActive(false);
    }
    public void OnCloseButtonClicked()
    {
        itemDetailsPannel.SetActive(false);
        confirmationPannel.SetActive(false);
        errorPannel.SetActive(false);
    }

    public void getRandomItem()
    {
        EventService.Instance.OnButtonRandomClickedEvent.InvokeEvent();
        itemWeightText.text = playerService.GetTotalWeight() + " / " + playerService.GetMaxWeight();
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
    public void GiveErrorMessage()
    {
        errorPannel.SetActive(true);
        confirmationPannel.SetActive(false);
    }
    
 }

}

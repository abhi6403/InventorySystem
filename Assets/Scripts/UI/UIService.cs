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
    
    private void ShowItemDetails(ItemModel itemData)
    {
        _itemModel = itemData;
        int quantityShop = shopService.GetItemQuantity(itemData);
        //int quantityInventory = _inventoryService.GetQuantityOfItem(itemData);

        itemDetailsImage.sprite = itemData.GetItemImage();
        itemName.text = itemData.GetItemName();
        itemDescription.text = itemData.GetItemDescription();
        itemBerries.text = itemData.GetItemPrice().ToString();
        itemQuantity.text = quantityShop.ToString();
        itemAvailableQuantity.text = quantityShop.ToString();
        itemWeight.text = itemData.GetItemWeight().ToString();
        
        itemDetailsPannel.SetActive(true);
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    private ItemController itemController;
    private Button thisbutton;

    public Image itemImage;
    public TextMeshProUGUI itemPrice;
    
    public GameObject itemDetails;
    public GameObject confirmationPannel;
    
    public Image itemDetailsImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemBerries;
    public TextMeshProUGUI itemQuantity;
    public TextMeshProUGUI itemAvailableQuantity;
    public TextMeshProUGUI itemAvailableInPlayer;
    public TextMeshProUGUI itemWeight;
    public Button plusButton;
    public Button minusButton;
    public Button closeButton;
    public Button buyButton;
    public Button SellButton;
    
    public Canvas mainCanvas;

    private void Start()
    {
        mainCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        itemDetails.SetActive(false);
        confirmationPannel.SetActive(false);
        itemAvailableInPlayer.gameObject.SetActive(false);
        SellButton.gameObject.SetActive(false);
        thisbutton = GetComponent<Button>();
        thisbutton.onClick.AddListener(itemController.ShowItemDetails);
    }

    public void SetItemController(ItemController _itemController)
    {
        itemController = _itemController;
    }

    public void InitializeItemDetails(ItemsScriptableObject _items)
    {
        itemDetailsImage.sprite = _items._sprite;
        itemName.text = _items._name;
        itemDescription.text = _items._description;
        itemBerries.text = "Berries - " + _items._amount;
        itemAvailableQuantity.text = "Available - " + _items._quantity;
        itemWeight.text = "Weight - " + _items._weight;
    }
    

    public Transform GetItemDetailsObjectTransform()
    {
        return mainCanvas.transform;
    }
    public void Initialize(Sprite _sprite, int _price)
    {
        itemImage.sprite = _sprite;
        itemPrice.text = _price.ToString();
    }

    public void CloseItemDetails()
    {
        itemController.CloseItemDetails();
    }

    public void ProcessConfirmButtonClicked()
    {
        itemController.processConfirmButtonClicked();
    }

    public void ProcessCancelButtonClicked()
    {
        itemController.processCancelButtonClicked();
    }
    public void ProcessPlusButton()
    {
        itemController.ProcessPlusButtonClicked();
    }

    public void ProcessMinusButton()
    {
        itemController.ProcessMinusButtonClicked();
    }
    public void PrcessBuyButton()
    {
        itemController.ProcessBuyButtonClicked();
    }

    public TextMeshProUGUI GetItemAvailableInPlayer()
    {
        return itemAvailableInPlayer;
    }
    public TextMeshProUGUI GetAvailableItemQuantityText()
    {
        return itemAvailableQuantity;
    }
    
    public GameObject GetItemDetails()
    {
        return itemDetails;
    }
    
    
}

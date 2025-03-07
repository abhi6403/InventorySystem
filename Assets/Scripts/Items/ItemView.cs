using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    private ItemController itemController;

    [SerializeField]private Image itemImage;
    [SerializeField]private Image itemDetailsImage;
    
    [SerializeField]private GameObject itemDetails;
    [SerializeField]private GameObject confirmationPannel;
    
    [SerializeField]private TextMeshProUGUI itemPrice;
    [SerializeField]private TextMeshProUGUI itemName;
    [SerializeField]private TextMeshProUGUI itemDescription;
    [SerializeField]private TextMeshProUGUI itemBerries;
    [SerializeField]private TextMeshProUGUI itemQuantity;
    [SerializeField]private TextMeshProUGUI itemAvailableQuantity;
    [SerializeField]private TextMeshProUGUI itemAvailableInPlayer;
    [SerializeField]private TextMeshProUGUI itemWeight;
    
    private Button thisbutton;
    [SerializeField]private Button plusButton;
    [SerializeField]private Button minusButton;
    [SerializeField]private Button closeButton;
    [SerializeField]private Button buyButton;
    [SerializeField]private Button SellButton;
    
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

    public void Initialize(Sprite _sprite, int _price)
    {
        itemImage.sprite = _sprite;
        itemPrice.text = _price.ToString();
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

    public void InitializePlayerItemDetails(ItemsScriptableObject _items)
    {
        itemAvailableQuantity.gameObject.SetActive(false);
        itemAvailableInPlayer.gameObject.SetActive(true);
        Debug.Log("Initiating in Player");
        itemDetailsImage.sprite = _items._sprite;
        itemName.text = _items._name;
        itemDescription.text = _items._description;
        itemBerries.text = "Berries - " + _items._amount;
        itemAvailableInPlayer.text = "Available - " + _items._inPlayerQuantity;
        itemWeight.text = "Weight - " + _items._weight;
    }
    public Transform GetItemDetailsObjectTransform()
    {
        return mainCanvas.transform;
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
    public void SetItemController(ItemController _itemController)
    {
        itemController = _itemController;
    }
    public TextMeshProUGUI GetItemAvailableInPlayer()
    {
        return itemAvailableInPlayer;
    }
    public TextMeshProUGUI GetAvailableItemQuantityText()
    {
        return itemAvailableQuantity;
    }

    public TextMeshProUGUI GetItemQuantityText()
    {
        return itemQuantity;
    }
    public GameObject GetItemDetails()
    {
        return itemDetails;
    }

    public GameObject GetConfirmationPannel()
    {
        return confirmationPannel;
    }
    
}

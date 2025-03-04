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
    
    public Image itemDetailsImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemBerries;
    public TextMeshProUGUI itemQuantity;
    public TextMeshProUGUI itemAvailableQuantity;
    public TextMeshProUGUI itemWeight;
    public Button plusButton;
    public Button minusButton;
    public Button closeButton;
    public Button buyButton;
    
    public Canvas mainCanvas;

    private void Start()
    {
        mainCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        itemDetails.SetActive(false);
        thisbutton = GetComponent<Button>();
        thisbutton.onClick.AddListener(itemController.ShowItemDetails);
    }

    public void SetItemController(ItemController _itemController)
    {
        itemController = _itemController;
    }

    public void InitializeItemDetailsUI(
        Sprite _sprite,
        String _name,
        String _description,
        int _berries,
        int _availableQuantity,
        int _weight)
    {
        itemDetailsImage.sprite = _sprite;
        itemName.text = _name;
        itemDescription.text = _description;
        itemBerries.text = "Berries - " + _berries;
        itemAvailableQuantity.text = "Available - " + _availableQuantity;
        itemWeight.text = "Weight - " + _weight;
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
        
    }
    
    public GameObject GetItemDetails()
    {
        return itemDetails;
    }
    
    
}

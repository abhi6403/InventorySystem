using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemService : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemPrice;
    
    public ItemDetails itemDetails;

    public GameObject detailsTab;
    
    public Canvas mainCanvas;

    private void Start()
    {
        mainCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void Initialize(Sprite _itemImage,string _itemName,string _itemDescription,string _itemPrice)
    {
        itemImage.sprite = _itemImage;
        itemName.text = _itemName;
        itemDescription.text = _itemDescription;
        itemPrice.text = _itemPrice;
    }

    public void setDetails()
    {
        itemDetails.Initialize(itemImage.sprite, itemName.text, itemDescription.text, itemPrice.text,5.ToString());
        ItemDetails Details = Instantiate(itemDetails, mainCanvas.transform);
        Debug.Log("itemDetails initialized");
    }
    
    public Sprite getItemImage()
    {
        return itemImage.sprite;
    }

    public TextMeshProUGUI getItemName()
    {
        return itemName;
    }

    public TextMeshProUGUI getItemDescription()
    {
        return itemDescription;
    }

    public TextMeshProUGUI getItemPrice()
    {
        return itemPrice;
    }
}   
    

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
    
    public ItemDetailsUI itemDetailsObject;
    
    
    public Canvas mainCanvas;

    private void Start()
    {
        mainCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        thisbutton = GetComponent<Button>();
        thisbutton.onClick.AddListener(itemController.ShowItemDetails);
    }

    public void SetItemController(ItemController _itemController)
    {
        itemController = _itemController;
    }

    public ItemDetailsUI GetItemDetailsObject()
    {
        return itemDetailsObject;
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
    
}

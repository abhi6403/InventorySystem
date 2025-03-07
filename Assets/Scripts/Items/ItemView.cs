using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    private ItemController itemController;

    [SerializeField]private Image itemImage;
    
    [SerializeField]private TextMeshProUGUI itemPrice;
    
    private Button thisbutton;
    
    
    public Canvas mainCanvas;

    private void Start()
    {
        mainCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        thisbutton = GetComponent<Button>();
        thisbutton.onClick.AddListener(itemController.ShowItemDetails);
    }

    public void Initialize(Sprite _sprite, int _price)
    {
        itemImage.sprite = _sprite;
        itemPrice.text = _price.ToString();
    }

    public void ShowItem()
    {
        gameObject.SetActive(true);
    }

    public void HideItem()
    {
        gameObject.SetActive(false);
    }
    
    public void SetItemController(ItemController _itemController)
    {
        itemController = _itemController;
    }

    
}

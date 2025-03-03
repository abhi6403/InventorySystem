using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    private ItemController itemController;

    public Image itemImage;
    public TextMeshProUGUI itemPrice;
    public ItemDetails itemDetails;

    public Canvas mainCanvas;

    private void Start()
    {
        mainCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }
    public void SetItemController(ItemController _controller)
    {
        itemController = _controller;
    }
    
    public void setDetails()
    {
        itemDetails.Initialize(
            itemController.GetItemImage(),
            itemController.GetItemName(),
            itemController.GetItemDescription(),
            itemController.GetItemPrice(),
            itemController.GetItemQuantity());
        ItemDetails Details = Instantiate(itemDetails, mainCanvas.transform);
    }

    public void Initialize(Sprite _sprite, int _price)
    {
        itemImage.sprite = _sprite;
        itemPrice.text = _price.ToString();
    }
}

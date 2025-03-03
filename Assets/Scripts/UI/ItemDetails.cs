using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ItemDetails : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI quantityText;
    

    public void Start()
    {
        image = this.transform.Find("ItemImage").GetComponent<Image>();
    }
    
    public void Initialize(Sprite _image,string _title, string _description, int _price, int _quantity)
    {
        image.sprite = _image;
        titleText.text =  _title;
        descriptionText.text = _description;
        priceText.text = "Price - " + _price;
        quantityText.text = _quantity.ToString();
    }
}

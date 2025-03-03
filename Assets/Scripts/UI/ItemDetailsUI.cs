using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailsUI : MonoBehaviour
{
    public Image itemDetailsImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemBerries;
    public TextMeshProUGUI itemQuantity;
    public TextMeshProUGUI itemAvailableQuantity;
    public TextMeshProUGUI itemWeight;

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
    
}

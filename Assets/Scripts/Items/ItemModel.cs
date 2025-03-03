using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemModel
{
   private ItemController itemController;
   
   private Sprite itemImage;
   private string itemName;
   private string itemDescription;
   private int itemPrice;
   private int itemAvailableQuantity;
   private int itemWeight;
   private int currentQuantity;
   private Transform parentTransform;
   private GameObject itemDetailsUI;
   private TextMeshProUGUI currentQuantityText;
   
   public ItemModel(Sprite _itemImage,string _itemName,string _itemDescription,int _itemPrice,int _availableQuantity,int _weight,Transform _parentTransform)
   {
      itemImage = _itemImage;
      itemName = _itemName;
      itemDescription = _itemDescription;
      itemPrice = _itemPrice;
      itemAvailableQuantity = _availableQuantity;
      itemWeight = _weight;
      parentTransform = _parentTransform;
   }

   public void SetItemDetailsUIGameObject(GameObject _gameObject)
   {
      itemDetailsUI = _gameObject;
   }
   public void SetItemController(ItemController _controller)
   {
      itemController = _controller;
   }

   public void IncreaseQuantity(int quantity)
   {
      if (currentQuantity < itemAvailableQuantity)
      {
         currentQuantity += quantity;
      }
   }

   public void DecreaseQuantity(int quantity)
   {
      if (currentQuantity > 0)
      {
         currentQuantity -= quantity;
      }
      
   }
   public void SetCurrentQuantityText(TextMeshProUGUI _currentQuantityText)
   {
      currentQuantityText = _currentQuantityText;
   }

   public int GetCurrentQuantity()
   {
      return currentQuantity;
   }
   public TextMeshProUGUI GetCurrentQuantityText()
   {
      return currentQuantityText;
   }
   public GameObject GetItemDetailsUIGameObject()
   {
      return itemDetailsUI;
   }
   public Transform GetParentTransform()
   {
      return parentTransform;
   }
   public Sprite GetItemImage()
   {
      return itemImage;
   }

   public string GetItemName()
   {
      return itemName;
   }

   public string GetItemDescription()
   {
      return itemDescription;
   }

   public int GetItemPrice()
   {
      return itemPrice;
   }

   public int GetItemQuantity()
   {
      return itemAvailableQuantity;
   }

   public int GetItemWeight()
   {
      return itemWeight;
   }
}

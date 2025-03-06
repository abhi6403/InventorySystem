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
   private int currentQuantityInPlayer;
   private Transform parentTransform;
   private GameObject itemDetailsUI;
   private TextMeshProUGUI currentQuantityText;
   private ItemsScriptableObject item;
   private ItemParentType itemParentType;
   
   public ItemModel(ItemsScriptableObject _itemsScriptableObject, Transform _parentTransform)
   {
      item = _itemsScriptableObject;
      //itemParentType = _itemParentType;
      itemImage = item._sprite;
      itemName = item.name;
      itemDescription = item._description;
      itemPrice = item._amount;
      itemAvailableQuantity = item._quantity;
      itemWeight = item._weight;
      currentQuantityInPlayer = item._inPlayerQuantity;
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

   public int GetCurrentQuantityInPlayer()
   {
      return currentQuantityInPlayer;
   }
   public void SetCurrentQuantity(int quantity)
   {
      currentQuantity = quantity;
   }
   public void SetCurrentQuantityText(TextMeshProUGUI _currentQuantityText)
   {
      currentQuantityText = _currentQuantityText;
   }

   public ItemsScriptableObject GetItem()
   {
      return item;
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

   public int GetItemAvailableQuantity()
   {
      return itemAvailableQuantity;
   }

   public int GetItemWeight()
   {
      return itemWeight;
   }
}

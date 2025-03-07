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
   private int itemAvailableQuantityInShop;
   private int itemAvailableQuantityInPlayer;
   private int itemWeight;
   private int currentQuantityInShop;
   private int currentQuantityInPlayer;
   

   private Transform parentTransform;

   private GameObject itemDetailsUI;

   private ItemsScriptableObject item;

   private ItemParentType itemParentType;
   private ItemTypes itemType;

   public ItemModel(ItemsScriptableObject _itemsScriptableObject, Transform _parentTransform,
      ItemParentType _itemParentType)
   {
      item = _itemsScriptableObject;
      itemImage = item._sprite;
      itemName = item._name;
      itemDescription = item._description;
      itemPrice = item._amount;
      itemAvailableQuantityInShop = item._fixedQuantity;
      itemAvailableQuantityInPlayer = 0;
      itemWeight = item._weight;
      itemType = item._itemType;
      parentTransform = _parentTransform;
   }
   
   //Setters
   public void SetItemController(ItemController _controller)
   {
      itemController = _controller;
   }

   public void SetItemDetailsUIGameObject(GameObject _gameObject)
   {
      itemDetailsUI = _gameObject;
   }

   public void SetCurrentQuantityInShop()
   {
      currentQuantityInShop = 0;
   }
   public void IncreaseAvailableQuantityInShop(int _quantity)
   {
      itemAvailableQuantityInShop += _quantity;
      item._quantity = itemAvailableQuantityInShop; 
      Debug.Log(itemAvailableQuantityInShop);
      //item._quantity += _quantity;
   }
   public void DecreaseAvailableQuantityInShop(int _quantity)
   {
      itemAvailableQuantityInShop -= _quantity;
      item._quantity = itemAvailableQuantityInShop;
      Debug.Log(itemAvailableQuantityInShop);
      //item._quantity -= _quantity;
   }
   public void IncreaseAvailableQuantityInPlayer(int _quantity)
   {
      itemAvailableQuantityInPlayer += _quantity;
      item._inPlayerQuantity = itemAvailableQuantityInPlayer;
      Debug.Log(itemAvailableQuantityInPlayer);
      //item._inPlayerQuantity += _quantity;
   }

   public void DecreaseAvailableQuantityInPlayer(int _quantity)
   {
      itemAvailableQuantityInPlayer -= _quantity;
      item._inPlayerQuantity = itemAvailableQuantityInPlayer;
      Debug.Log(itemAvailableQuantityInPlayer);
      //item._inPlayerQuantity -= _quantity;
   }
   public void IncreaseCurrentQuantityInShop(int _quantity)
   {
      currentQuantityInShop += _quantity;
   }
   public void DecreaseCurrentQuantityInShop(int _quantity)
   {
      currentQuantityInShop -= _quantity;
   }
   public void IncreaseCurrentQuantityInPlayer(int _quantity)
   {
      currentQuantityInPlayer += _quantity;
   }  

   public void DecreaseCurrentQuantityInPlayer(int _quantity)
   {
      currentQuantityInPlayer -= _quantity;
   }

   //Getters
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

   public int GetItemAvailableQuantityInShop()
   {
      return item._quantity;
   }

   public int GetAvailableQuantityInPlayer()
   {
      return item._inPlayerQuantity;
   }

   public int GetItemWeight()
   {
      return itemWeight;
   }

   public int GetCurrentQuantityInShop()
   {
      return currentQuantityInShop;
   }

   public int GetCurrentQuantityInPlayer()
   {
      return currentQuantityInPlayer;
   }

   public Transform GetParentTransform()
   {
      return parentTransform;
   }

   public GameObject GetItemDetailsUIGameObject()
   {
      return itemDetailsUI;
   }
   

   public ItemsScriptableObject GetItem()
   {
      return item;
   }

   public ItemParentType GetItemParentType()
   {
      return itemParentType;
   }

   public ItemTypes GetItemType()
   {
      return itemType;
   }
}
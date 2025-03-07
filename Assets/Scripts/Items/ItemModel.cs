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
   private int itemWeight;
   
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
      item._quantity = item._fixedQuantity;
      item._inPlayerQuantity = 0;
      itemWeight = item._weight;
      itemType = item._itemType;
      parentTransform = _parentTransform;
      itemParentType = _itemParentType;
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
   
   public int GetItemWeight()
   {
      return itemWeight;
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

   public int GetQantityOfPlayer()
   {
      return item._inPlayerQuantity;
   }

   public int GetQuantityOfShop()
   {
      return item._quantity;
   }
}
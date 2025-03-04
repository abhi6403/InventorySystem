using UnityEngine;
using UnityEngine.UI;

public class ItemModel
{
   private ItemController itemController;
   
   private Sprite itemImage;
   private string itemName;
   private string itemDescription;
   private int itemPrice;
   private int itemQuantity;
   private int itemWeight;
   private Transform parentTransform;
   public GameObject itemDetailsUI;
   
   public ItemModel(Sprite _itemImage,string _itemName,string _itemDescription,int _itemPrice,int _quantity,int _weight,Transform _parentTransform)
   {
      itemImage = _itemImage;
      itemName = _itemName;
      itemDescription = _itemDescription;
      itemPrice = _itemPrice;
      itemQuantity = _quantity;
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
      return itemQuantity;
   }

   public int GetItemWeight()
   {
      return itemWeight;
   }
}

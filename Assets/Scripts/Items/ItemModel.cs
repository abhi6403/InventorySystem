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

   private TextMeshProUGUI currentQuantityTextInShop;
   private TextMeshProUGUI currentQuantityTextInPlayer;
   private TextMeshProUGUI availableQuantityInShopText;
   private TextMeshProUGUI availableQuantityInPlayerText;

   private ItemsScriptableObject item;

   private ItemParentType itemParentType;

   public ItemModel(ItemsScriptableObject _itemsScriptableObject, Transform _parentTransform,
      ItemParentType _itemParentType)
   {
      item = _itemsScriptableObject;
      itemParentType = _itemParentType;
      itemImage = item._sprite;
      itemName = item.name;
      itemDescription = item._description;
      itemPrice = item._amount;
      item._quantity = item._fixedQuantity;
      itemWeight = item._weight;
      item._inPlayerQuantity = 0;
      itemAvailableQuantityInPlayer = item._inPlayerQuantity;
      itemAvailableQuantityInShop = item._quantity;
      parentTransform = _parentTransform;
   }

   private void SetPlayerItemQuantity()
   {
      if (item._inPlayerQuantity != 0)
      {
         item._inPlayerQuantity = 0;
      }
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

   public void SetCurrentQuantityTextInShop()
   {
      currentQuantityTextInShop = itemDetailsUI.transform.Find("CurrentItemQuantity").GetComponent<TextMeshProUGUI>();
   }
   public void SetCurrentQuantityTextInPlayer()
   {
      currentQuantityTextInPlayer =  itemDetailsUI.transform.Find("CurrentItemQuantity").GetComponent<TextMeshProUGUI>();
   }

   public void SetAvailableQuantityTextInShop()
   {
      availableQuantityInShopText =  itemDetailsUI.transform.Find("AvailableQuantityInShop").GetComponent<TextMeshProUGUI>();
   }

   public void SetAvailableQuantityTextInPlayer()
   {
      availableQuantityInPlayerText = itemDetailsUI.transform.Find("AvailableQuantityInPlayer").GetComponent<TextMeshProUGUI>();
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

   public TextMeshProUGUI GetCurrentQuantityTextInShop()
   {
      return currentQuantityTextInShop;
   }

   public TextMeshProUGUI GetCurrentQuantityTextInPlayer()
   {
      return currentQuantityTextInPlayer;
   }

   public TextMeshProUGUI GetAvailableQuantityInShopText()
   {
      return availableQuantityInShopText;
   }

   public TextMeshProUGUI GetAvailableQuantityInPlayerText()
   {
      return availableQuantityInPlayerText;
   }

   public ItemsScriptableObject GetItem()
   {
      return item;
   }

   public ItemParentType GetItemParentType()
   {
      return itemParentType;
   }
}
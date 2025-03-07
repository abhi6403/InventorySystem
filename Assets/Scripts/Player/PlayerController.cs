using System.Collections.Generic;
using TMPro;
using static UnityEngine.Object;
using UnityEngine;

public class PlayerController 
{
    private PlayerView playerView;
    private int weight;
    private const int maxWeight = 150;
    
    private ItemView itemView;
    private TextMeshProUGUI playerItemAvailableText;
    private int playerItemAvailable;

    public PlayerController(PlayerView _playerView,ItemView _itemView)
    {
        itemView = _itemView;
        playerView = _playerView;
        playerView.SetPlayerController(this);
        EventService.Instance.OnBuyButtonClickedEvent.AddListener(AddToPlayerInventory);
        
    }

    public void AddToPlayerInventory(ItemsScriptableObject _itemsScriptableObject)
    {
       
        if (OnBuyItems(_itemsScriptableObject) == false)
        {
            for (int i = 0; i < playerView.inventory.items.Count; i++)
            {
                if (playerView.inventory.items[i].name ==
                    _itemsScriptableObject.name)
                {
                    GetItemsInPlayerInventory().Add(_itemsScriptableObject);
                    weight += _itemsScriptableObject._weight * _itemsScriptableObject._inPlayerQuantity;
                    Debug.Log(weight.ToString());
                }
            }
        }
        clearAllItems();
        /*for (int i = 0; i < playerView.GetItemsInPlayerInventory().Count; i++)
        {
            ItemService item = new ItemService(itemView, playerView.GetItemsInPlayerInventory()[i], GetPlayerInventoryTransform(),ItemParentType.PLAYER);
        }*/
    }
    
    public void clearAllItems()
    {
        foreach (Transform child in GetPlayerInventoryTransform())
        {
            Destroy(child.gameObject);
        }
    }

    public void AddWeightText()
    {
        playerView.GetWeightText().text = weight + "/150";
    }
    public bool OnBuyItems(ItemsScriptableObject _itemsScriptableObject)
    {
        bool added = false;

        for (int i = 0; i < GetItemsInPlayerInventory().Count; i++)
        {
            if (GetItemsInPlayerInventory()[i]._name == _itemsScriptableObject._name)
            {
                Debug.Log("Item is already added to player inventory");
                added = true;
                break;
            }
        }
        return added;
    }
    
    public List<ItemsScriptableObject> GetItemsInPlayerInventory()
    {
       return playerView.GetItemsInPlayerInventory();
    }
    
    public Transform GetPlayerInventoryTransform()
    {
        return playerView.GetPlayerInventoryTransform();
    }
}

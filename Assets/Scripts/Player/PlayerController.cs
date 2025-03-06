using System.Collections.Generic;
using TMPro;
using static UnityEngine.Object;
using UnityEngine;

public class PlayerController 
{
    private PlayerView playerView;
    
    private InventoryService inventoryService;
    private ItemView itemView;
    private TextMeshProUGUI playerItemAvailableText;
    private int playerItemAvailable;

    public PlayerController(PlayerView _playerView, InventoryService _inventoryService,ItemView _itemView)
    {
        itemView = _itemView;
        inventoryService = _inventoryService;
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
                    _itemsScriptableObject._inPlayerQuantity = 1;
                }
            }
        }
        clearAllItems();
        for (int i = 0; i < playerView.GetItemsInPlayerInventory().Count; i++)
        {
            ItemService item = new ItemService(itemView, playerView.GetItemsInPlayerInventory()[i], GetPlayerInventoryTransform(),ItemParentType.PLAYER);
        }
    }
    
    public void clearAllItems()
    {
        foreach (Transform child in GetPlayerInventoryTransform())
        {
            Destroy(child.gameObject);
        }
    }

    public bool OnBuyItems(ItemsScriptableObject _itemsScriptableObject)
    {
        bool added = false;

        for (int i = 0; i < GetItemsInPlayerInventory().Count; i++)
        {
            if (GetItemsInPlayerInventory()[i]._name == _itemsScriptableObject._name)
            {
                _itemsScriptableObject._inPlayerQuantity++;
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

    public InventoryView GetInventoryView()
    {
        return playerView.GetInventoryView();
    }
    public Transform GetPlayerInventoryTransform()
    {
        return playerView.GetPlayerInventoryTransform();
    }
}

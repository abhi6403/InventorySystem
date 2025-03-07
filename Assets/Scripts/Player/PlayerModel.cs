using System.Collections.Generic;
using UnityEngine;

public class PlayerModel 
{
    private PlayerController _playerController;

    private List<ItemController> _playerItemList;

    public PlayerModel()
    {
        _playerItemList = new List<ItemController>();
    }
    ~PlayerModel() { }

    public void SetController(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public void AddItem(ItemController newItem)
    {
        _playerItemList.Add(newItem);
    }

    public void RemoveItem(ItemController item)
    {
        _playerItemList.Remove(item);
    }

    public List<ItemController> PlayerItemList { get => _playerItemList; }
}

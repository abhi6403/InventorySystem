using System.Collections.Generic;
using UnityEngine;

public class PlayerModel 
{
    private PlayerController _playerController;

    private List<ItemController> _playerItemList;

    private int _totalBerries;

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

    public int GetTotalBerries()
    {
        return _totalBerries;
    }

    public void SetTotalBerries(int totalBerries)
    {
        _totalBerries = totalBerries;
    }
}

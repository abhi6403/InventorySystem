using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "Scriptable Objects/InventorySystem/FoodObject")]

public class FoodObject : ItemObject
{
    public int restoreHealthValue;
    public void Awake()
    {
        itemType = ItemType.HEALTH;
    }
}

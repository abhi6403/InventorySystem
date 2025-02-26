using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/InventorySystem/WeaponObject")]

public class WeaponObject : ItemObject
{
    public float Damage;
    public void Awake()
    {
        itemType = ItemType.WEAPON;
    }
}

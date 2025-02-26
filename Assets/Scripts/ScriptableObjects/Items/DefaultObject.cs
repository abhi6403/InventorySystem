using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultObject", menuName = "Scriptable Objects/InventorySystem/DefaultObject")]
public class DefaultObject : ItemObject
{
    public void Awake()
    {
        itemType = ItemType.DEFAULT;
    }
}

using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryScriptableObject", menuName = "Scriptable Objects/InventoryScriptableObject")]
public class InventoryScriptableObject : ScriptableObject
{
    public List<ItemsScriptableObject> items;
    
        
}

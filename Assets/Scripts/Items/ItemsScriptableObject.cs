using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ItemsScriptableObject", menuName = "Scriptable Objects/ItemsScriptableObject")]
public class ItemsScriptableObject : ScriptableObject
{
    public Sprite _sprite;
    public string _name;
    public int _amount;
    public int _fixedQuantity;
    public int _quantity;
    public int _weight;
    public int _inPlayerQuantity;
    public ItemTypes _itemType;
    
    [TextArea(10,15)]
    public string _description;
    
}

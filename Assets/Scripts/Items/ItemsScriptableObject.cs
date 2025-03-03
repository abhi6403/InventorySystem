using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ItemsScriptableObject", menuName = "Scriptable Objects/ItemsScriptableObject")]
public class ItemsScriptableObject : ScriptableObject
{
    public Sprite _sprite;
    public string _name;
    public string _amount;
    public ItemTypes _itemType;
    public int _quantity;
    
    [TextArea(10,15)]
    public string _description;
    
}

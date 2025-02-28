using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ItemsScriptableObject", menuName = "Scriptable Objects/ItemsScriptableObject")]
public class ItemsScriptableObject : ScriptableObject
{
    public Sprite _sprite;
    public float _amount;
    public ItemTypes _itemType;
}

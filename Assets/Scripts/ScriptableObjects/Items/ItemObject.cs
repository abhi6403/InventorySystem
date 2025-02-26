using UnityEngine;

public enum ItemType
{
    HEALTH,
    WEAPON,
    DEVILFRUIT,
    MAP,
    PROPS,
    COSTUME,
    DEFAULT,
}
public class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType itemType;
    [TextArea(15, 20)]
    public string description;
}

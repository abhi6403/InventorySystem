using UnityEngine;
using UnityEngine.UIElements;

public class ItemPrefab : MonoBehaviour
{
    public Image image;
    public ItemPrefab(Sprite _sprite)
    {
       image.sprite = _sprite;
    }
}

using UnityEngine;
using UnityEngine.Serialization;

public class ShopView : MonoBehaviour
{
    private ShopController shopController;
    
    [SerializeField]
    private InventoryScriptableObject shopInventoryObject;
    [SerializeField]
    private Transform shopTransform;
    [SerializeField]
    private InventoryView inventoryView;

    public void SetShopController(ShopController _shopController)
    {
        shopController = _shopController;
    }

    public void ShowAllItems()
    {
        shopController.ShowAllItems();
    }

    public void ShowInventoryItem(ItemTypes _itemType)
    {
        shopController.ShowInventoryItem(_itemType);
    }
    public InventoryScriptableObject GetShopInventoryObject()
    {
        return shopInventoryObject;
    }

    public Transform GetShopTransform()
    {
        return shopTransform;
    }

    public InventoryView GetInventoryView()
    {
        return inventoryView;
    }
}

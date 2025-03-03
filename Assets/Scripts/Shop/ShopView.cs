using UnityEngine;

public class ShopView : MonoBehaviour
{
    private ShopController shopController;
    
    [SerializeField]
    private InventoryScriptableObject shopScriptableObject;
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
    public InventoryScriptableObject GetShopScriptableObject()
    {
        return shopScriptableObject;
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

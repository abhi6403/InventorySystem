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

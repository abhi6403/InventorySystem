using UnityEngine;

public class ShopController 
{
    private ShopModel shopModel;
    private ShopView shopView;

    public ShopController(ShopModel _shopModel, ShopView _shopView)
    {
        shopModel = _shopModel;
        shopView = _shopView;
        
        shopView.SetShopController(this);
        shopModel.SetShopController(this);
    }

    public InventoryController  SetInventory()
    {
        InventoryModel inventoryModel = new InventoryModel(GetShopScriptableObject(),GetShopTransform());
        InventoryController inventoryController = new InventoryController(inventoryModel,GetInventoryView());
        return inventoryController;
    }
    public void ShowAllItems()
    {
        SetInventory().ShowInventory();
    }

    public void ShowInventoryItem(ItemTypes _itemType)
    {
        SetInventory().ShowInventoryItem(_itemType);
    }
    public Transform GetShopTransform()
    {
        return shopView.GetShopTransform();
    }

    public InventoryScriptableObject GetShopScriptableObject()
    {
        return shopView.GetShopInventoryObject();
    }

    public InventoryView GetInventoryView()
    {
        return shopView.GetInventoryView();
    }
}

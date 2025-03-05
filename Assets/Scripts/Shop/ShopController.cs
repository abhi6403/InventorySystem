using UnityEngine;

public class ShopController 
{
    private ShopView shopView;

    public ShopController(ShopView _shopView)
    {
        shopView = _shopView;
        shopView.SetShopController(this);
        EventService.Instance.OnButtonAllClickedEvent.AddListener(ShowAllItems);
        EventService.Instance.OnFilterButtonClickedEvent.AddListener(ShowInventoryItem);
    }

     ~ShopController()
    {
        EventService.Instance.OnButtonAllClickedEvent.RemoveListener(ShowAllItems);
        //EventService.Instance.OnFilterButtonClickedEvent.RemoveListener(ShowInventoryItem);
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

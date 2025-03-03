using UnityEngine;

public class InventoryController
{
    private InventoryView inventoryView;
    private InventoryModel inventoryModel;

    public InventoryController( InventoryModel _inventoryModel,InventoryView _inventoryView)
    {
        inventoryModel = _inventoryModel;
        inventoryView = _inventoryView;
        
        ShowInventory();
    }

    public void ShowInventory()
    {
        for (int i = 0; i < GetInventoryScriptableObject().items.Count; i++)
        {
            int itemPrice = GetInventoryScriptableObject().items[i]._amount;
            string itemName = GetInventoryScriptableObject().items[i]._name;
            string itemDescription = GetInventoryScriptableObject().items[i]._description;
            int itemQuantity = GetInventoryScriptableObject().items[i]._quantity;
            int itemWeight = GetInventoryScriptableObject().items[i]._weight;
            Sprite sprite = GetInventoryScriptableObject().items[i]._sprite;
            Transform itemTransform = GetInventoryTransform().transform;
            
            ItemModel itemModel = new ItemModel(sprite,itemName,itemDescription,itemPrice,itemQuantity,itemWeight,itemTransform);
            ItemController itemController = new ItemController(itemModel,GetItemView());
        }
    }

    public void SortInventoryItem(ItemTypes itemType)
    {
        for (int i = 0; i < GetInventoryScriptableObject().items.Count; i++)
        {
            if(GetInventoryScriptableObject().items[i]._itemType == itemType)
            {
                int itemPrice = GetInventoryScriptableObject().items[i]._amount;
                string itemName = GetInventoryScriptableObject().items[i]._name;
                string itemDescription = GetInventoryScriptableObject().items[i]._description;
                int itemQuantity = GetInventoryScriptableObject().items[i]._quantity;
                Sprite sprite = GetInventoryScriptableObject().items[i]._sprite;
                int itemWeight = GetInventoryScriptableObject().items[i]._weight;
                Transform itemTransform = GetInventoryTransform().transform;

                ItemModel itemModel = new ItemModel(sprite,itemName,itemDescription,itemPrice,itemQuantity,itemWeight,itemTransform);
                ItemController itemController = new ItemController(itemModel,GetItemView());
            }
        }
    }
    
    public ItemView GetItemView()
    {
        return inventoryView.GetItemView();
    }
    public InventoryScriptableObject GetInventoryScriptableObject()
    {
        return inventoryModel.GetInventoryscriptableObject();
    }

    public Transform GetInventoryTransform()
    {
        return inventoryModel.GetInventoryTransform();
    }
}

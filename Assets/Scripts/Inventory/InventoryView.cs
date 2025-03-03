using UnityEngine;

public class InventoryView : MonoBehaviour
{
    private InventoryController inventoryController;

    [SerializeField]
    private ItemView itemView;
    
    public void SetInventoryController(InventoryController _inventoryController)
    {
        inventoryController = _inventoryController;
    }

    public void ShowAllItems()
    {
        inventoryController.ShowInventory();
    }
    public void ShowInventoryItem(ItemTypes _itemType)
    {
        inventoryController.ShowInventoryItem(_itemType);
    }
    public void clearAllItems()
    {
        foreach (Transform child in inventoryController.GetInventoryTransform() )
        {
            Destroy(child.gameObject);
        }
    }

    public ItemView GetItemView()
    {
        return itemView;
    }
}

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
    

    public ItemView GetItemView()
    {
        return itemView;
    }
}

using UnityEngine;

public class InventoryModel 
{
    private InventoryController inventoryController;

    private InventoryScriptableObject inventoryscriptableObject;
    private Transform inventoryTransform;

    public InventoryModel(InventoryScriptableObject _inventoryscriptableObject, Transform _inventoryTransform)
    {
        inventoryscriptableObject = _inventoryscriptableObject;
        inventoryTransform = _inventoryTransform;
    }
    
    public void SetInventoryController(InventoryController _inventoryController)
    {
        inventoryController = _inventoryController;
    }

    public InventoryScriptableObject GetInventoryscriptableObject()
    {
        return inventoryscriptableObject;
    }

    public Transform GetInventoryTransform()
    {
        return inventoryTransform;
    }
}

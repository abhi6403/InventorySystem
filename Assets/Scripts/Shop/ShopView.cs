using UnityEngine;

namespace Inventory.Shop
{
    public class ShopView : MonoBehaviour
    {
        private ShopController shopController;

        [SerializeField] private InventoryScriptableObject shopInventoryObject;
        [SerializeField] private Transform shopTransform;

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
    }
}

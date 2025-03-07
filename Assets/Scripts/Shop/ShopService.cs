
using Inventory.Item;
using Inventory.Player;
using Inventory.UI;

namespace Inventory.Shop
{
    public class ShopService
    {
        private ShopController shopController;

        public void Initialize(ShopView shopView, ItemView _itemView, ItemService _itemService,
            PlayerService playerService, UIService uiService)
        {
            shopController = new ShopController(shopView, _itemView, _itemService, playerService, uiService);
        }

        public int GetSelectionQuantity()
        {
            return shopController.GetSelectedQuantity();
        }

        public void SetSelectionQuantity(int quantity)
        {
            shopController.SetSelectionQuantity(quantity);
        }
    }
}

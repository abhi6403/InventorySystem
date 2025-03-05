using UnityEngine;

public class ShopService 
{
    private ShopController shopController;
    public void Initialize(ShopView shopView)
    {
        shopController = new ShopController(shopView);
        ShowAllItems();
    }
    
    public void ShowAllItems()
    {
        shopController.ShowAllItems();
    }
    
}

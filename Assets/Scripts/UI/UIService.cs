using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
   public ShopView shopView;

   

   private void setShop()
   {
       ShopModel shopModel = new ShopModel();
       ShopController shopController = new ShopController(shopModel, shopView);
       
   }
   public void getAllItems()
    {
        setShop();
        shopView.ShowAllItems();
    }

    public void getWeaponItems()
    {
        setShop();
        shopView.ShowInventoryItem(ItemTypes.WEAPON);
    }
    public void getFoodItems()
    {
        setShop();
        shopView.ShowInventoryItem(ItemTypes.HEALTH);
    }

    public void getDevilFruits()
    {
        setShop();
        shopView.ShowInventoryItem(ItemTypes.DEVILFRUIT);
    }

    public void getPosters()
    {
        setShop();
        shopView.ShowInventoryItem(ItemTypes.POSTER);
    }
    
    public void getProps()
    {
        setShop();
        shopView.ShowInventoryItem(ItemTypes.PROPS);
    }
    
    public void getPotions()
    {
        setShop();
        shopView.ShowInventoryItem(ItemTypes.POTION);
    }
    
    public void getShipItems()
    {
        setShop();
        shopView.ShowInventoryItem(ItemTypes.SHIPITEMS);
    }
    
    public void getMap()
    {
        setShop();
        shopView.ShowInventoryItem(ItemTypes.MAP);
    }
}

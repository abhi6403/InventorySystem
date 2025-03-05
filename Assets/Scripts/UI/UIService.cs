using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
   public PlayerView playerView;
   

   public void ShowAllItemsInPlayerInventory()
   {
       playerView.ShowItemsInPlayerInventory();
   }
   public void getAllItemsInShop()
    {
        EventService.Instance.OnButtonAllClickedEvent.InvokeEvent();
    }

    public void getWeaponItems()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.WEAPON);
    }
    public void getFoodItems()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.HEALTH);
    }

    public void getDevilFruits()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.DEVILFRUIT);
    }

    public void getPosters()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.POSTER);
    }
    
    public void getProps()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.PROPS);
    }
    
    public void getPotions()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.POTION);
    }
    
    public void getShipItems()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.SHIPITEMS);
    }
    
    public void getMap()
    {
        EventService.Instance.OnFilterButtonClickedEvent.InvokeEvent(ItemTypes.MAP);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
   private PlayerController playerController;
   
   [SerializeField]
   private Transform playerInventoryTransform;
   [SerializeField]
   private InventoryView inventoryView;
   [SerializeField]
   private List<ItemsScriptableObject> playerItems;

   public void SetPlayerController(PlayerController _playerController)
   {
      playerController = _playerController;
   }

   public List<ItemsScriptableObject> GetItemsInPlayerInventory()
   {
      return playerItems;
   }

   public Transform GetPlayerInventoryTransform()
   {
      return playerInventoryTransform;
   }

   public InventoryView GetInventoryView()
   {
      return inventoryView;
   }
}

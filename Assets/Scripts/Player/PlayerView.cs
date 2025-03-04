using UnityEngine;

public class PlayerView : MonoBehaviour
{
   private PlayerController playerController;
   
   
   [SerializeField]
   private Transform playerInventoryTransform;
   [SerializeField]
   private InventoryView inventoryView;

   public void SetPlayerController(PlayerController _playerController)
   {
      playerController = _playerController;
   }

   public void ShowItemsInPlayerInventory()
   {
      playerController.ShowItemsInPlayerInventory();
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

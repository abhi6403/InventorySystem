using UnityEngine;

public class PlayerView : MonoBehaviour
{
   private PlayerController playerController;
   
   [SerializeField]
   private InventoryScriptableObject shopInventoryObject;
   [SerializeField]
   private Transform playerTransform;

   public void SetPlayerController(PlayerController _playerController)
   {
      playerController = _playerController;
   }

   public Transform GetPlayerTransform()
   {
      return playerTransform;
   }

   public InventoryScriptableObject GetInventoryObject()
   {
      return shopInventoryObject;
   }
}

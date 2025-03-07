using System.Collections.Generic;
using TMPro;
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
   
   [SerializeField]
   private TextMeshProUGUI weightText;
   public InventoryScriptableObject inventory;

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

   public TextMeshProUGUI GetWeightText()
   {
      return weightText;
   }
   public InventoryScriptableObject GetPlayerInventory()
   {
      return inventory;
   }
   public InventoryView GetInventoryView()
   {
      return inventoryView;
   }
}

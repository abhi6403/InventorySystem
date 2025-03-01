using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    public InventoryScriptableObject inventoryScriptableObject;
    public Transform inventoryContainer;
    public GameObject itemPrefab;
    
    public void initialize()
    {
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            itemPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventoryScriptableObject.items[i]._amount.ToString();
            itemPrefab.transform.GetChild(1).GetComponent<Image>().sprite = inventoryScriptableObject.items[i]._sprite;
            GameObject item = Instantiate(itemPrefab, inventoryContainer);
        }
    }

    public void getAllItems()
    {
        initialize();
    }

    public void getWeaponItems()
    {
        clearAllItems();
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.WEAPON)
            {
                itemPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventoryScriptableObject.items[i]._amount.ToString();
                itemPrefab.transform.GetChild(1).GetComponent<Image>().sprite = inventoryScriptableObject.items[i]._sprite;
                GameObject item = Instantiate(itemPrefab, inventoryContainer);
            }
        }
    }

    public void getFoodItems()
    {
        clearAllItems();

        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.HEALTH)
            {
                itemPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventoryScriptableObject.items[i]._amount.ToString();
                itemPrefab.transform.GetChild(1).GetComponent<Image>().sprite = inventoryScriptableObject.items[i]._sprite;
                GameObject item = Instantiate(itemPrefab, inventoryContainer);
            }
        }
    }

    public void getDevilFruits()
    {
        clearAllItems();
        
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.DEVILFRUIT)
            {
                itemPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventoryScriptableObject.items[i]._amount.ToString();
                itemPrefab.transform.GetChild(1).GetComponent<Image>().sprite = inventoryScriptableObject.items[i]._sprite;
                GameObject item = Instantiate(itemPrefab, inventoryContainer);
            }
        }
    }

    public void getPosters()
    {
        clearAllItems();
        
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.POSTER)
            {
                itemPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventoryScriptableObject.items[i]._amount.ToString();
                itemPrefab.transform.GetChild(1).GetComponent<Image>().sprite = inventoryScriptableObject.items[i]._sprite;
                GameObject item = Instantiate(itemPrefab, inventoryContainer);
            }
        }
    }
    
    public void getProps()
    {
        clearAllItems();
        
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.PROPS)
            {
                itemPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventoryScriptableObject.items[i]._amount.ToString();
                itemPrefab.transform.GetChild(1).GetComponent<Image>().sprite = inventoryScriptableObject.items[i]._sprite;
                GameObject item = Instantiate(itemPrefab, inventoryContainer);
            }
        }
    }
    
    public void getPotions()
    {
        clearAllItems();
        
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.POTION)
            {
                itemPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventoryScriptableObject.items[i]._amount.ToString();
                itemPrefab.transform.GetChild(1).GetComponent<Image>().sprite = inventoryScriptableObject.items[i]._sprite;
                GameObject item = Instantiate(itemPrefab, inventoryContainer);
            }
        }
    }
    
    public void getShipItems()
    {
        clearAllItems();
        
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.SHIPITEMS)
            {
                itemPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventoryScriptableObject.items[i]._amount.ToString();
                itemPrefab.transform.GetChild(1).GetComponent<Image>().sprite = inventoryScriptableObject.items[i]._sprite;
                GameObject item = Instantiate(itemPrefab, inventoryContainer);
            }
        }
    }
    
    public void getMap()
    {
        clearAllItems();
        
        for (int i = 0; i < inventoryScriptableObject.items.Count; i++)
        {
            if (inventoryScriptableObject.items[i]._itemType == ItemTypes.MAP)
            {
                itemPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventoryScriptableObject.items[i]._amount.ToString();
                itemPrefab.transform.GetChild(1).GetComponent<Image>().sprite = inventoryScriptableObject.items[i]._sprite;
                GameObject item = Instantiate(itemPrefab, inventoryContainer);
            }
        }
    }

    public void clearAllItems()
    {
        foreach (Transform child in inventoryContainer )
        {
            Destroy(child.gameObject);
        }
    }
}

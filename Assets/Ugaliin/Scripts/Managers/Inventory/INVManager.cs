using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;   

public class INVManager : MonoBehaviour
{
    private static INVManager instance;
    public List<Item> inventory = new List<Item>();
    private List<Item> instantiatedItems = new List<Item>(); // Keep track of instantiated items

    public Transform BackpackContent;
    public Transform ItemContent;
    public GameObject InventoryItem;

    public GameObject BackpackItem;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }

    public static INVManager GetInstance()
    {
        return instance;
    }

    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    void Update()
    {
        ListItems();
    }

    public void ListItems()
    {
        foreach (var item in inventory)
        {
            // Check if the item has already been instantiated
            if (!instantiatedItems.Contains(item))
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                if (obj == null)
                {
                    Debug.LogError("Failed to instantiate InventoryItem prefab.");
                    continue; // Skip to the next iteration of the loop
                }
                GameObject backpackObj = Instantiate(BackpackItem, BackpackContent);
                if (backpackObj == null)
                {
                    Debug.LogError("Failed to instantiate BackpackItem prefab.");
                    continue; // Skip to the next iteration of the loop
                }



                var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
                if (itemName == null)
                {
                    Debug.LogError("ItemName component not found on instantiated object.");
                    Destroy(obj); // Clean up the object
                    continue; // Skip to the next iteration of the loop
                }
                var backpackName = backpackObj.transform.Find("ItemName").GetComponent<TMP_Text>();
                if (backpackName == null)
                {
                    Debug.LogError("ItemName component not found on instantiated object.");
                    Destroy(backpackObj); // Clean up the object
                    continue; // Skip to the next iteration of the loop
                }

                var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
                if (itemIcon == null)
                {
                    Debug.LogError("ItemIcon component not found on instantiated object.");
                    Destroy(obj); // Clean up the object
                    continue; // Skip to the next iteration of the loop
                }

                var backpackIcon = backpackObj.transform.Find("ItemIcon").GetComponent<Image>();
                if (backpackIcon == null)
                {
                    Debug.LogError("ItemIcon component not found on instantiated object.");
                    Destroy(backpackObj); // Clean up the object
                    continue; // Skip to the next iteration of the loop
                }

                backpackName.text = item.itemName;
                backpackIcon.sprite = item.icon;
                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;

                // Add the item to the instantiated items list
                instantiatedItems.Add(item);
            }
        }
    }
}


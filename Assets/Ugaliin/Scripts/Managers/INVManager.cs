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

    public Transform ItemContent;
    public GameObject InventoryItem;

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

    public void RemoveItem(Item item)
    {
        inventory.Remove(item);
        // Remove item from instantiated items list if it exists
        instantiatedItems.Remove(item);
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

                var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
                if (itemName == null)
                {
                    Debug.LogError("ItemName component not found on instantiated object.");
                    Destroy(obj); // Clean up the object
                    continue; // Skip to the next iteration of the loop
                }

                var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
                if (itemIcon == null)
                {
                    Debug.LogError("ItemIcon component not found on instantiated object.");
                    Destroy(obj); // Clean up the object
                    continue; // Skip to the next iteration of the loop
                }

                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;

                // Add the item to the instantiated items list
                instantiatedItems.Add(item);
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class INVManager : MonoBehaviour, IDataPersistance
{   
    //Essentials
    private static INVManager instance;
    public List<Item> inventory = new List<Item>();
    private List<Item> instantiatedItems = new List<Item>(); // Keep track of instantiated items

    //Item Content Variables
    public Transform BackpackContent;
    public Transform ItemContent;
    public GameObject InventoryItem;
    public GameObject BackpackItem;

    //Backpack Content Variables
    public TMP_Text BackpackName;
    public TMP_Text BackpackDescription;
    public Image BackpackIcon;

    private bool inventoryChanged = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }

    public void Start()
    {
        // Ensure the default values are set when the game starts
        if (inventory.Count > 0)
        {
            UpdateBackpackUI(inventory[0]);
        }
    }

    public static INVManager GetInstance()
    {
        return instance;
    }

    public void AddItem(Item item)
    {
        inventory.Add(item);
        inventoryChanged = true; 
    }

    public void Update()
    {
        if (inventoryChanged)
        {
            ListItems();
            inventoryChanged = false; // Reset the flag after updating the list
        }
    }

    public void ListItems()
    {
        // Clear existing UI elements to avoid duplicatio
        foreach (Transform child in ItemContent)
        {
            // Destroy the child game object
            Destroy(child.gameObject);
        }
        foreach (Transform child in BackpackContent)
        {
            // Destroy the child game object
            Destroy(child.gameObject);
        }
        instantiatedItems.Clear();

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
                Debug.Log("Instantiated InventoryItem: " + obj.name);

                GameObject backpackObj = Instantiate(BackpackItem, BackpackContent);
                if (backpackObj == null)
                {
                    Debug.LogError("Failed to instantiate BackpackItem prefab.");
                    continue; // Skip to the next iteration of the loop
                }
                Debug.Log("Instantiated BackpackItem: " + backpackObj.name);


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

                var backpackInventoryIcon = backpackObj.transform.Find("ItemIcon").GetComponent<Image>();
                if (backpackInventoryIcon == null)
                {
                    Debug.LogError("ItemIcon component not found on instantiated object.");
                    Destroy(backpackObj); // Clean up the object
                    continue; // Skip to the next iteration of the loop
                }

                
                backpackInventoryIcon.sprite = item.icon;
                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;

                // Add the item to the instantiated items list
                instantiatedItems.Add(item);

                Button button = obj.GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.AddListener(() => UpdateBackpackUI(item));
                }
                else
                {
                    Debug.LogError("No Button component found on the instantiated InventoryItem prefab.");
                }


                Button backpackButton = backpackObj.GetComponent<Button>();
                if (backpackButton != null)
                {
                    backpackButton.onClick.AddListener(() => UpdateBackpackUI(item));
                    Debug.Log("Button component found and listener added on BackpackItem.");
                }
                else
                {
                    Debug.LogError("No Button component found on the instantiated BackpackItem prefab.");
                }

                // Set default backpack item and description if this is the first item
                if (instantiatedItems.Count == 1)
                {
                    UpdateBackpackUI(item);
                }
            }
        }
    }

    public void UpdateBackpackUI(Item item)
    {
        BackpackName.text = item.itemName;
        BackpackDescription.text = item.description;
        BackpackIcon.sprite = item.icon;
    }

    public void LoadData(GameData data)
    {
        inventory.Clear();
        foreach (var itemName in data.inventoryItemNames)
        {
            Item item = Resources.Load<Item>($"Items/{itemName}"); // Assuming your ScriptableObjects are stored in a Resources/Items folder
            if (item != null)
            {
                inventory.Add(item);
            }
            else
            {
                Debug.LogWarning($"Item with name {itemName} not found in Resources/Items folder.");
            }
        }
        ListItems();
    }

    public void SaveData(ref GameData data)
    {
        data.inventoryItemNames.Clear();
        foreach (var item in inventory)
        {
            data.inventoryItemNames.Add(item.name);
        }
    }

}


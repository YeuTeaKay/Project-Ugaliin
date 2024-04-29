using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INVManager : MonoBehaviour
{
    
    private static INVManager instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }
    
    public void AddItem(Item item)
    {

    }

    public void RemoveItem(Item item)
    {
        
    }

    public void ListItems()
    {

    }
}

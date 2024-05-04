using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    public Item item;

    void PickUp()
    {
        INVManager.GetInstance().AddItem(item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        PickUp();
    }

}

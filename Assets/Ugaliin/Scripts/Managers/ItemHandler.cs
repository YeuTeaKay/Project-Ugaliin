using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public Item item;

    public void GiveItem()
    {
        INVManager.GetInstance().AddItem(item);
    }
}

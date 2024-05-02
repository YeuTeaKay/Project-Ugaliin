using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public Item rightItem;
    public Item otherItem;

    public void Update()
    {
        bool isRightChoice = ((Ink.Runtime.BoolValue) VNManager.GetInstance().GetVariableState("rightChoice")).value;

        if (isRightChoice == true)
        {
            GiveRightItem();
        }
        else
        {
            GiveOtherItem();
        }
    }

    public void GiveOtherItem()
    {
        INVManager.GetInstance().AddItem(otherItem);
    }


    public void GiveRightItem()
    {
        INVManager.GetInstance().AddItem(rightItem);
    }
}

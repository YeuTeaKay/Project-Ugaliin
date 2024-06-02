using System.Collections;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private Item choiceItem0;
    [SerializeField] private Item choiceItem1;
    [SerializeField] private Item choiceItem2;

    private bool actionPerformed = false;


    private void Update()
    {
        if (!actionPerformed)
        {
            string IsplayerChoice = ((Ink.Runtime.StringValue) VNManager
            .GetInstance()
            .GetVariableState("playerChoice")).value;

            switch (IsplayerChoice)
            {
                case "choiceItem0":
                    Debug.Log("player choice: " + IsplayerChoice);
                    GiveItem(choiceItem0);
                    actionPerformed = true;
                    break;
                case "choiceItem1":
                    Debug.Log("player choice: " + IsplayerChoice);
                    GiveItem(choiceItem1);
                    actionPerformed = true;
                    break;
                case "choiceItem2":
                    Debug.Log("player choice: " + IsplayerChoice);
                    GiveItem(choiceItem2);
                    actionPerformed = true;
                    break;
                default:
                    Debug.LogWarning("Player Choice was not found: " + IsplayerChoice);
                    break;
            }
        }
    }

    private void GiveItem(Item item)
    {
        INVManager.GetInstance().AddItem(item);
    }




}

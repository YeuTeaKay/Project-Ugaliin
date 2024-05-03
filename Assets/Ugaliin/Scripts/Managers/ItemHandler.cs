using System.Collections;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private Item choiceItem0;
    [SerializeField] private Item choiceItem1;
    [SerializeField] private Item choiceItem2;


    private void Update()
    {
        string IsplayerChoice = ((Ink.Runtime.StringValue) VNManager
            .GetInstance()
            .GetVariableState("playerChoice")).value;

        switch (IsplayerChoice)
        {
            case "choiceItem0":
                Debug.Log("player choice: " + IsplayerChoice);
                break;
            case "choiceItem1":
                Debug.Log("player choice: " + IsplayerChoice);
                break;
            case "choiceItem2":
                Debug.Log("player choice: " + IsplayerChoice);
                break;
            default:
                Debug.LogWarning("Player Choice was not found: " + IsplayerChoice);
                break;
        }
    }

    private void GiveItem()
    {
        //INVManager.GetInstance().AddItem(otherItem);

    }

}

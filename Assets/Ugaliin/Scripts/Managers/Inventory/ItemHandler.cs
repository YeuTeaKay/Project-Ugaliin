using System.Collections;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private Item[] choiceItems;
    [SerializeField] private Item[] removeItems;

    private bool actionPerformed = false;

    private void Update()
    {
        if (!actionPerformed)
        {
            string playerChoice = ((Ink.Runtime.StringValue)VNManager.GetInstance().GetVariableState("playerChoice")).value;

            if (playerChoice.StartsWith("choiceItem"))
            {
                int index = int.Parse(playerChoice.Substring("choiceItem".Length));
                if (index >= 0 && index < choiceItems.Length)
                {
                    Debug.Log("Player choice (good): " + playerChoice);
                    GiveItem(choiceItems[index]);
                    actionPerformed = true;
                    ResetPlayerChoice();
                }
            }
            else if (playerChoice.StartsWith("removeItem"))
            {
                int index = int.Parse(playerChoice.Substring("removeItem".Length));
                if (index >= 0 && index < removeItems.Length)
                {
                    Debug.Log("Player choice (bad): " + playerChoice);
                    RemoveItem(removeItems[index]);
                    actionPerformed = true;
                    ResetPlayerChoice();
                }
            }
            else
            {
                Debug.LogWarning("Player choice was not found: " + playerChoice);
            }
        }
    }

    private void GiveItem(Item item)
    {
        INVManager.GetInstance().AddItem(item);
    }

    private void RemoveItem(Item item)
    {
        INVManager.GetInstance().RemoveItem(item);
    }

    private void ResetPlayerChoice()
    {
        VNManager.GetInstance().SetVariableState("playerChoice", new Ink.Runtime.StringValue(""));
        actionPerformed = false;
    }
}

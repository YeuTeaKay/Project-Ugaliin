using UnityEngine;

[CreateAssetMenu(fileName = "Reputation", menuName = "Reputation/Traits")]
public class Reputation : ScriptableObject
{
    [SerializeField] private string reputationName;
    [SerializeField] private int reputationCounter;
    
    public string ReputationName
    {
        get { return reputationName; }
    }

    public int ReputationCounter
    {
        get { return reputationCounter; }
    }
}
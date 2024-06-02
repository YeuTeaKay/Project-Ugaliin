using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "Quest/QuestInfoSO", order = 1)]
public class QuestInfoSO : ScriptableObject
{
    public string questID;
    public string questFullDescription;
    public string questShortDescription;
    public string questObjective;
}

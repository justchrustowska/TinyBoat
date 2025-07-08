using UnityEngine;

[CreateAssetMenu(menuName = "Quest")]
public class QuestData : ScriptableObject
{
    public string questId;
    public string questName;
    public string description;
    public QuestObjective[] objectives;
    public int requiredCount;
    public string itemToCollectId;
}
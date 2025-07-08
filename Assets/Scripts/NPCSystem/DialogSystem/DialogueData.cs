using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/NPC Dialogue")]
public class DialogueData : ScriptableObject
{
    public string speakerName;
    [TextArea(2, 5)] public string[] lines;
    public QuestData questToGive; // can be null
}
using System.Runtime.CompilerServices;
using UnityEngine;

public class QuestProgressUpdatedEvent : IQuestEvent
{
    public string questId;
    public int currentCount;

    public QuestProgressUpdatedEvent(string questId, int currentCount)
    {
        this.questId = questId;
        this.currentCount = currentCount;
    }

    public string ObjectiveId => questId;
}

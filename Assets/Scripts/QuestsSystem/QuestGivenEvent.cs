using UnityEngine;

public class QuestGivenEvent : IQuestEvent
{
    public string ObjectiveId => quest.questId;
    public QuestData quest;

    public QuestGivenEvent(QuestData quest)
    {
        this.quest = quest;
    }
}

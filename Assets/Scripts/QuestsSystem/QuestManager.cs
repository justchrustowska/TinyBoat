using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<QuestProgress> activeQuests = new();
    public List<QuestProgress> GetActiveQuests()
    {
        return activeQuests;
    }

    private void OnEnable() => QuestEventChannel.OnEvent += HandleEvent;
    private void OnDisable() => QuestEventChannel.OnEvent -= HandleEvent;

    private void HandleEvent(IQuestEvent questEvent)
    {
        if (questEvent is QuestGivenEvent given)
        {
            if (!activeQuests.Any(q => q.Data.questId == given.quest.questId))
                activeQuests.Add(new QuestProgress(given.quest));
        }

        foreach (var quest in activeQuests)
        {
            quest.ApplyEvent(questEvent);
        }
    }
}

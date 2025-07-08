using System;
using System.Collections.Generic;
using UnityEngine;


public class QuestSystem
{
    private readonly List<QuestProgress> _activeQuests = new();

    public event Action<QuestProgress> OnQuestCompleted;

    public void AddQuest(QuestData questData)
    {
        var progress = new QuestProgress(questData);
        _activeQuests.Add(progress);
    }

    public void HandleEvent(IQuestEvent questEvent)
    {
        foreach (var quest in _activeQuests)
        {
            quest.ApplyEvent(questEvent);
            if (quest.IsCompleted)
            {
                OnQuestCompleted?.Invoke(quest);
            }
        }
    }
}

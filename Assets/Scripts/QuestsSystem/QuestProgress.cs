using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestProgress
{
    public QuestData Data { get; private set; }
    public int CurrentCount { get; private set; }
    public bool IsCompleted => CurrentCount >= Data.requiredCount;

    public QuestProgress(QuestData data)
    {
        Data = data;
        CurrentCount = CurrentCount;
    }

    public void ApplyEvent(IQuestEvent e)
    {
        Debug.Log($"[QuestProgress] ApplyEvent: {e.GetType().Name} for quest {Data.questName}");

        if (e is ItemCollectedEvent collected)
        {
            Debug.Log($"[QuestProgress] Comparing collected.itemId ({collected.itemId}) to Data.itemToCollectId ({Data.itemToCollectId})");
        }

        if (e is ItemCollectedEvent collected2 && collected2.itemId == Data.itemToCollectId && !IsCompleted)
        {
            Debug.Log($"[QuestProgress] Item collected: {collected2.itemId}, amount: {collected2.amount}");
            CurrentCount += collected2.amount;

            QuestEventChannel.Raise(new QuestProgressUpdatedEvent(Data.questId, CurrentCount));
        }
    }
}

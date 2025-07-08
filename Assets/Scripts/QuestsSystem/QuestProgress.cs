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
        if (e is ItemCollectedEvent collected && collected.itemId == Data.itemToCollectId && !IsCompleted)
        {
            Debug.Log($"Item collected: {collected.itemId} Amount: {collected.amount}");
            Debug.Log($"[QuestProgress] Item collected: {collected.itemId} Amount: {collected.amount} => CurrentCount: {CurrentCount}/{Data.requiredCount}");
            CurrentCount += collected.amount;
            
            QuestEventChannel.Raise(new QuestProgressUpdatedEvent(Data.questId, CurrentCount));
        }
    }
}

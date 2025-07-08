using System;
using TMPro;
using UnityEngine;

public class QuestUIEntry : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questText;
    private QuestData quest;

    public void Initialize(QuestData data)
    {
        quest = data;
        questText.text = $"{quest.questName} – 0 / {quest.requiredCount}";
    }

    private void OnEnable()
    {
        QuestEventChannel.OnEvent += HandleEvent;
    }

    private void OnDisable()
    {
        QuestEventChannel.OnEvent -= HandleEvent;
    }

    private void HandleEvent(IQuestEvent e)
    {
        if (e is QuestProgressUpdatedEvent update && update.questId == quest.questId)
        {
            questText.text = $"{quest.questName} – {update.currentCount} / {quest.requiredCount}";
        }
    }
    
}


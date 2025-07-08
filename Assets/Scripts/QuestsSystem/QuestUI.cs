using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public GameObject questEntryPrefab;
    public Transform questListContainer;

    private Dictionary<QuestData, QuestUIEntry> activeEntries = new();

    private void OnEnable()
    {
        QuestEventChannel.OnEvent += OnQuestEvent;
    }

    private void OnDisable()
    {
        QuestEventChannel.OnEvent -= OnQuestEvent;
    }

    private void OnQuestEvent(IQuestEvent e)
    {
        Debug.Log($"QuestUI received event: {e.GetType().Name}");
        if (e is QuestGivenEvent given)
        {
            Debug.Log($"Adding quest: {given.quest.questName}");
            AddQuest(given.quest);
        }
    }

    private void AddQuest(QuestData quest)
    {
        if (activeEntries.ContainsKey(quest)) return;

        GameObject obj = Instantiate(questEntryPrefab, questListContainer);
        QuestUIEntry entry = obj.GetComponent<QuestUIEntry>();
        entry.Initialize(quest);

        activeEntries.Add(quest, entry);

        entry.Initialize(quest);
    }
}

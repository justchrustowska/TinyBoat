using System;
using UnityEngine;

public class QuestEventChannel : MonoBehaviour
{
    public static event Action<IQuestEvent> OnEvent;

    public static void Raise(IQuestEvent questEvent)
    {
        OnEvent?.Invoke(questEvent);
    }
}

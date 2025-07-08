using UnityEngine;

public class ItemCollectedEvent : IQuestEvent
{
    public string itemId;
    public int amount;

    public string ObjectiveId => itemId;

    public ItemCollectedEvent(string itemId, int amount = 1)
    {
        this.itemId = itemId;
        this.amount = amount;
    }
}

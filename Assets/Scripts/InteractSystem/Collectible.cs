using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string objectiveId;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestEventChannel.Raise(new ItemCollectedEvent(objectiveId));
            Destroy(gameObject);
        }
    }
}

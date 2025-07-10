using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [Header("Dialoges")]
    public DialogueData dialogueDefault;
    public DialogueData dialogueQuestDone;
    public string questIdToCheck;

    private bool _isPlayerNear;

    private void Update()
    {
        if (_isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            DialogueData dialogueToShow = dialogueDefault;
            
            QuestManager qm = FindObjectOfType<QuestManager>();
            var quest = qm.GetActiveQuests()
                .Find(q => q.Data.questId == questIdToCheck);

            if (quest != null && quest.IsCompleted)
            {
                dialogueToShow = dialogueQuestDone;
            }
            DialogueUI.Instance.ShowDialogue(dialogueToShow);
        }

        if (_isPlayerNear && DialogueUI.Instance != null && Input.GetKeyDown(KeyCode.Space))
        {
            DialogueUI.Instance.OnNextLine();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _isPlayerNear = false;
    }
}

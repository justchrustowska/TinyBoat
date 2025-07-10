using TMPro;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance;

    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private string[] lines;
    private int index;
    private DialogueData currentDialogue;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        Hide();
    }

    public void ShowDialogue(DialogueData dialogue)
    {
        currentDialogue = dialogue;
        lines = dialogue.lines;
        index = 0;
        panel.SetActive(true);
        speakerNameText.text = dialogue.speakerName;
        dialogueText.text = lines[index];
    }

    public void OnNextLine()
    {
        if (currentDialogue == null) 
        {
            return;
        }

        index++;
        if (index < lines.Length)
        {
            dialogueText.text = lines[index];
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        panel.SetActive(false);

        if (currentDialogue.questToGive != null)
        {
            QuestEventChannel.Raise(new QuestGivenEvent(currentDialogue.questToGive));
            Debug.Log("Quest received: " + currentDialogue.questToGive.questName);
        }

        currentDialogue = null;
    }

    public void Hide() => panel.SetActive(false);
}

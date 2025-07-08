using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogueData dialogueData;
    private bool isPlayerNear = false;

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            DialogueUI.Instance.ShowDialogue(dialogueData);
            Debug.Log("Dialog trigger clicked");
        }

        if (isPlayerNear && DialogueUI.Instance != null && Input.GetKeyDown(KeyCode.Space))
        {
            DialogueUI.Instance.OnNextLine();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Transform nameText;
    public Transform dialogueText;

    public GameObject dialogueBox;

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true);
        }

        nameText.GetComponent<TMPro.TextMeshProUGUI>().text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = sentence;
    }

    void EndDialogue()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
    }
}

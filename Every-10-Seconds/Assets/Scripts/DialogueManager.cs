using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Transform nameText;
    public Transform dialogueText;

    public GameObject dialogueBox;

    public GameObject leftChoice;
    public GameObject rightChoice;

    private Queue<string> sentences;

    private Dialogue dia;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        dia = dialogue;

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


        if (sentences.Count == 1)
        {
            rightChoice.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = dia.rightChoice;
            rightChoice.SetActive(true);

            leftChoice.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = dia.leftChoice;
            leftChoice.SetActive(true);
        } else
        {
            rightChoice.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "continue >>>";
            rightChoice.SetActive(true);
        }

        string sentence = sentences.Dequeue();
        dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = sentence;
    }

    void EndDialogue()
    {
        if (dialogueBox != null)
        {
            rightChoice.SetActive(false);
            leftChoice.SetActive(false);
            dialogueBox.SetActive(false);
        }
    }
}

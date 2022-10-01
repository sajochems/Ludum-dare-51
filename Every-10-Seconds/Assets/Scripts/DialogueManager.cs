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

    private int flag;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        flag = 0;
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
            if (flag == 0)
            {
                rightChoice.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = dia.rightChoice;
                rightChoice.SetActive(true);

                leftChoice.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = dia.leftChoice;
                leftChoice.SetActive(true);
                flag = 1;

            }
            else
            {
                EndDialogue();
                return;
            }
        }


        string sentence = sentences.Dequeue();
        dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = sentence;
        rightChoice.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "continue >>>";
        rightChoice.SetActive(true);
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

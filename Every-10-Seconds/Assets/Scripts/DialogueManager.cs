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
    private NPC npc;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        dia = dialogue;
        npc = dialogue.npc;

        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true);
        }

        nameText.GetComponent<TMPro.TextMeshProUGUI>().text = dialogue.npc.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void rightClick()
    {
        npc.SetRelationship(npc.GetRelationship() + dia.rightValue);
    }

    void leftClick()
    {
        npc.SetRelationship(npc.GetRelationship() + dia.leftValue);
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
            rightChoice.GetComponent<Button>().onClick.AddListener(rightClick);
            rightChoice.SetActive(true);

            leftChoice.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = dia.leftChoice;
            leftChoice.GetComponent<Button>().onClick.AddListener(leftClick);
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
            rightChoice.GetComponent<Button>().onClick.RemoveListener(rightClick);
            leftChoice.SetActive(false);
            leftChoice.GetComponent<Button>().onClick.RemoveListener(leftClick);
            dialogueBox.SetActive(false);
            Debug.Log("the npc's relationship is: " + npc.GetRelationship());
        }
    }
}

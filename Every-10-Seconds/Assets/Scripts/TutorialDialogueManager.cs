using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialogueManager : MonoBehaviour
{
    public Transform nameText;
    public Transform dialogueText;

    public GameObject dialogueBox;

    public GameObject leftChoice;
    public GameObject rightChoice;

    public SceneChanger sceneChanger;
    public string nextScene;

    private Queue<string> sentences;

    private Dialogue dia;
    private NPC npc;

    private int flag;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        dia = dialogue;
        npc = dialogue.npc;
        flag = 0;

        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true);
        }

        nameText.GetComponent<TMPro.TextMeshProUGUI>().text = dialogue.npc.name;

        /*sentences.Clear();*/

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void rightClick()
    {

        npc.Value += dia.rightValue;
        sentences.Enqueue(dia.rightResponse);

        flag = 1;

        rightChoice.SetActive(false);
        rightChoice.GetComponent<Button>().onClick.RemoveListener(rightClick);
        leftChoice.SetActive(false);
        leftChoice.GetComponent<Button>().onClick.RemoveListener(leftClick);
    }

    void leftClick()
    {
        npc.Value += dia.leftValue;
        sentences.Enqueue(dia.leftResponse);


        rightChoice.GetComponent<Button>().onClick.RemoveListener(rightClick);
        leftChoice.SetActive(false);
        leftChoice.GetComponent<Button>().onClick.RemoveListener(leftClick);

        foreach (string sentence in dia.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }

    public void DisplayNextSentence()
    {
        StartCoroutine(DisplaySentence());
    }

    IEnumerator DisplaySentence()
    {
        yield return new WaitForSeconds(0.1f);
        if (sentences.Count == 0)
        {
            EndDialogue();
            yield break;
        }


        if (sentences.Count == 1 && flag == 0)
        {
            rightChoice.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = dia.rightChoice;
            rightChoice.GetComponent<Button>().onClick.AddListener(rightClick);
            rightChoice.SetActive(true);

            leftChoice.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = dia.leftChoice;
            leftChoice.GetComponent<Button>().onClick.AddListener(leftClick);
            leftChoice.SetActive(true);
        }
        else
        {
            rightChoice.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "continue >>>";
            rightChoice.SetActive(true);
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = sentence;
    }

    void EndDialogue()
    {
        if (dialogueBox != null)
        {
            dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = " ";
            dialogueBox.SetActive(false);
            Debug.Log("the npc's relationship is: " + npc.Value);
        }

        sceneChanger.NextScene(nextScene);
    }
}

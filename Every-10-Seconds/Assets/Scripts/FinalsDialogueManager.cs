using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalsDialogueManager : MonoBehaviour
{
    public Transform nameText;
    public Transform dialogueText;

    public GameObject dialogueBox;

    public GameObject rightChoice;

    public GameObject characterSprite;

    public NPCManager npcManager;

    public SceneChanger sceneChanger;
    public string nextScene;

    public GameObject[] todisable;

    private Queue<string> sentences;

    private FinalsDialogue dia;
    private NPC npc;

    private int flag;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(FinalsDialogue dialogue)
    {

        dia = dialogue;
        npc = dialogue.npc;
        flag = 0;

        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true);
        }

        characterSprite.GetComponent<Image>().sprite = npc.Image;

        nameText.GetComponent<TMPro.TextMeshProUGUI>().text = dialogue.npc.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (GameObject gameObject in todisable)
        {
            gameObject.SetActive(false);
        }

        DisplayNextSentence();
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
            if(flag == 0)
            {
                if (npcManager.GetAllies().Count > npcManager.GetRivals().Count)
                {
                    foreach (string s in dia.winningResult)
                    {
                        sentences.Enqueue(s);
                    }
                } else
                {
                    foreach (string s in dia.losingResult)
                    {
                        sentences.Enqueue(s);
                    }
                }

            } else
            {
                EndDialogue();
                yield break;
            }
            flag = 1;
            
        }

        rightChoice.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "continue >>>";
        rightChoice.SetActive(true);
        string sentence = sentences.Dequeue();
        dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = sentence;
    }

    void EndDialogue()
    {
        if (dialogueBox != null)
        {
            dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = " ";
            dialogueBox.SetActive(false);
        }


        sceneChanger.NextScene(nextScene);
    }
}

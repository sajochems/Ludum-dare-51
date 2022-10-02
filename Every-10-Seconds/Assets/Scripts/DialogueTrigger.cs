using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue; 

    public void TriggerDialogue()
    {
        if(FindObjectOfType<DialogueManager>() != null)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        } else
        {
            FindObjectOfType<TutorialDialogueManager>().StartDialogue(dialogue);
        }
        
    }
}

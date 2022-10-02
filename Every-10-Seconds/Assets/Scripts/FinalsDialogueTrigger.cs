using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalsDialogueTrigger : MonoBehaviour
{
    public FinalsDialogue dialogue;

    public void TriggerDialogue()
    {

        FindObjectOfType<FinalsDialogueManager>().StartDialogue(dialogue);
    
    }
}

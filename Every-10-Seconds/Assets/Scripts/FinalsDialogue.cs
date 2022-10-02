using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FinalsDialogue
{
    [SerializeField]
    public NPC npc;

    [TextArea(3, 10)]
    public string[] winningResult;

    [TextArea(3, 10)]
    public string[] losingResult;

    [TextArea(3, 10)]
    public string[] sentences;
}

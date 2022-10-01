using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public NPC npc;

    public string leftChoice;
    public int leftValue;

    public string rightChoice;
    public int rightValue;

    [TextArea(3, 10)]
    public string[] sentences;
}

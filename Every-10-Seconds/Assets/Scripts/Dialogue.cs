using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField]
    public NPC npc;

    [TextArea(3, 10)]
    public string leftChoice;
    public int leftValue;

    [TextArea(3, 10)]
    public string leftResponse;

    [TextArea(3, 10)]
    public string rightChoice;
    public int rightValue;

    [TextArea(3, 10)]
    public string rightResponse;

    [TextArea(3, 10)]
    public string[] sentences;
}

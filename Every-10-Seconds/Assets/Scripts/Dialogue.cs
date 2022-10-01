using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField]
    public NPC npc;

    public string leftChoice;
    public int leftValue;
    public string leftResponse;

    public string rightChoice;
    public int rightValue;
    public string rightResponse;

    [TextArea(3, 10)]
    public string[] sentences;
}

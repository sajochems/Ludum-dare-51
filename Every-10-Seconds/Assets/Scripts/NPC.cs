using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPC 
{
    public string name;
    private int relationship;
    void Start()
    {
        relationship = 0;
    }

    public void SetRelationship(int newvalue)
    {
        relationship = newvalue;
    }

    public int GetRelationship()
    {
        return relationship;
    }

}

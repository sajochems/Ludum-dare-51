using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public NPC[] npcs;

    private List<NPC> allies;

    private List<NPC> rivals;

    private void Start()
    {
        foreach(NPC npc in npcs)
        {
            if(npc.Value > 0)
            {
                allies.Add(npc);
            } else
            {
                rivals.Add(npc);
            }
        }
    }
}

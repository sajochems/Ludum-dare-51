using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    public NPC[] npcs;

    public GameObject leftCanvas;
    public GameObject rightCanvas;


    private List<NPC> allies;
    private List<NPC> rivals;

    private void Start()
    {
        allies = new List<NPC>();
        rivals = new List<NPC>();
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

        int indicator = 1;

        foreach (NPC allie in allies)
        {
            leftCanvas.transform.Find("Allie" + indicator).gameObject.SetActive(true);
            leftCanvas.transform.Find("Allie" + indicator).gameObject.GetComponent<Image>().sprite = allie.Image;
            indicator += 1;
        }

        indicator = 9;
        foreach (NPC rival in rivals)
        {
            rightCanvas.transform.Find("Rival" + indicator).gameObject.SetActive(true);
            rightCanvas.transform.Find("Rival" + indicator).gameObject.GetComponent<Image>().sprite = rival.Image;
            indicator -= 1;
        }
    }

    public List<NPC> GetAllies()
    {
        return allies;
    }

    public List<NPC> GetRivals()
    {
        return rivals;
    }

    public void DisableTeams()
    {
        int indicator = 1;

        foreach (NPC allie in allies)
        {
            leftCanvas.transform.Find("Allie" + indicator).gameObject.SetActive(false);
            indicator += 1;
        }

        indicator = 9;
        foreach (NPC rival in rivals)
        {
            rightCanvas.transform.Find("Rival" + indicator).gameObject.SetActive(false);
            indicator -= 1;
        }
    }
}

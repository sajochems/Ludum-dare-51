using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameValues : MonoBehaviour
{
    [SerializeField]
    private NPC Bagman;

    [SerializeField]
    private NPC Beer;

    [SerializeField]
    private NPC Blubber;

    [SerializeField]
    private NPC Cactus;

    [SerializeField]
    private NPC DemonBoy;

    [SerializeField]
    private NPC Kharl;

    [SerializeField]
    private NPC Lucinda;

    [SerializeField]
    private NPC Missy;

    [SerializeField]
    private NPC MrSheep;

    [SerializeField]
    private NPC MrWorm;

    [SerializeField]
    private NPC MusicMan;

    [SerializeField]
    private NPC Mystery;

    [SerializeField]
    private NPC Ned;

    [SerializeField]
    private NPC Placeholder;

    [SerializeField]
    private NPC TutorialFairy;

    private void Start()
    {
        Bagman.Value = 0;
        Beer.Value = 0;
        Blubber.Value = 0;
        Cactus.Value = 0;
        DemonBoy.Value = 0;
        Kharl.Value = 0;
        Lucinda.Value = 0;
        Missy.Value = 0;
        MrSheep.Value = 0;
        MrWorm.Value = 0;
        MusicMan.Value = 0;
        Mystery.Value = 0;
        Ned.Value = 0;
        Placeholder.Value = 0;
        TutorialFairy.Value = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameValues : MonoBehaviour
{
    [SerializeField]
    private NPC TutorialFairy;

    [SerializeField]
    private NPC MrSheep;

    [SerializeField]
    private NPC MrWorm;

    private void Start()
    {
        TutorialFairy.Value = 0;
        MrSheep.Value = 0;
        MrWorm.Value = 0;
    }
}

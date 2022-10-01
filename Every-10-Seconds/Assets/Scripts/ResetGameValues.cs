using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameValues : MonoBehaviour
{
    [SerializeField]
    private NPC TutorialFairy;

    [SerializeField]
    private NPC SlimShady;

    private void Start()
    {
        TutorialFairy.Value = 0;
        SlimShady.Value = 0;
    }
}

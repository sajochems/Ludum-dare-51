using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneChanger sceneChanger;

    public void StartGame()
    {
        sceneChanger.NextScene("Tutorial");
    }
}

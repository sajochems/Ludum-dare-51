using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public void StartGame()
    {
        menu.SetActive(false);
        SceneManager.LoadSceneAsync("Scene01", LoadSceneMode.Additive);
    }
}

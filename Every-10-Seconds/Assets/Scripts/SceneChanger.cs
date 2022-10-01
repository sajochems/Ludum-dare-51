using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject[] todisable;
    public void NextScene(string nextScene)
    {
        foreach( GameObject gameObject in todisable)
        {
            gameObject.SetActive(false);
        }
       
        SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
    }
  
}

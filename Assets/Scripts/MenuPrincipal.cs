using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPrincipal : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MainSceneWithUI");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

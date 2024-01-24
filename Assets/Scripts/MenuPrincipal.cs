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

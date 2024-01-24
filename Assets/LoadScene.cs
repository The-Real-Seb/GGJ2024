using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public float duration;


    private void Start()
    {
        StartCoroutine(LoadMenu());
    }

    public IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene("MenuPrincipal");
    }
}

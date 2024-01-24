using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadMenu());
    }

    public IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(11);

        SceneManager.LoadScene("MenuPrincipal");
    }
}

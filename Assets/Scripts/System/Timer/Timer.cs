using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    private static Timer instance = null;
    public static Timer Instance => instance;

    public Slider slider;

    public float countdown;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }


    private void Update()
    {
        if (countdown > 0)
            countdown -= Time.deltaTime;
        else if (countdown <= 0)
            StartCoroutine(GameOver());

        slider.value = countdown;
    }

    public IEnumerator GameOver()
    {
        GameManager.Instance.currentFace.sprite = GameManager.Instance.angryFace;

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Credits");
    }
}

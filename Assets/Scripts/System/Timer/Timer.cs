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
    public float currentTimer;


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
        if (currentTimer > 0)
            currentTimer -= Time.deltaTime;
        else if (currentTimer <= 0)
            StartCoroutine(GameOver());

        slider.value = currentTimer / countdown;
    }

    public IEnumerator GameOver()
    {
        GameManager.Instance.currentFace.sprite = GameManager.Instance.angryFace;

        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene("Credits");
    }
}

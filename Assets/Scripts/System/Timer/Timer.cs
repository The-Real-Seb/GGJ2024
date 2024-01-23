using UnityEngine;

public class Timer : MonoBehaviour
{
    private static Timer instance = null;
    public static Timer Instance => instance;

    private float countdown;

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

        countdown = DialogueSystem.Instance._replique.repliqueDuration;
    }


    private void Update()
    {
        if (countdown > 0)
            countdown -= Time.deltaTime;


    }
}

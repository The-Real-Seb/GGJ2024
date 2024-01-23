using UnityEngine;

public class Timer : MonoBehaviour
{
    private static Timer instance = null;
    public static Timer Instance => instance;



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
    }
}

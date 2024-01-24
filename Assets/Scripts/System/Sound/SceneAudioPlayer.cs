using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SceneAudioPlayer : MonoBehaviour
{

    private AudioSource audioSource;
    private float playbackSpeed = 1.0f; // Default playback speed
    public float SpeedMultiplicator;

    private static SceneAudioPlayer instance = null;
    public static SceneAudioPlayer Instance => instance;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

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




    public void AccelerateMusicSpeed()
    {
        playbackSpeed = playbackSpeed * SpeedMultiplicator;
        audioSource.pitch = playbackSpeed;
    }

   
}

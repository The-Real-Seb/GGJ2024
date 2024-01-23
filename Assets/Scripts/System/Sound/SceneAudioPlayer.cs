using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SceneAudioPlayer : MonoBehaviour
{

    private AudioSource audioSource;
    private float playbackSpeed = 1.0f; // Default playback speed
    public float SpeedMultiplicator;



    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


        // Example method to be called when you trigger a custom event to change playback speed
        public void ChangePlaybackSpeed()
    {
        playbackSpeed = playbackSpeed * SpeedMultiplicator;
        audioSource.pitch = playbackSpeed;
    }

   
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class DialogueSystem : MonoBehaviour
{
    public Reponse firstReponse;
    [Range(0.1f,100f)]
    public float typingSpeed;
    public GameObject layoutGroup;
    public GameObject buttonPrefab;
    public TextMeshProUGUI texteReplique;

    private bool canPass = false;
    public Replique _replique;
    private int _IdReplique = 0;
    private List<Replique> _ListReplique = new List<Replique>();
    private static DialogueSystem instance = null;
    public static DialogueSystem Instance => instance;
    private AudioSource audioSource;


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

    private void Update()
    {
        if (Input.anyKey)
        {
            //ShowNextReplique();
        }
    }

    public void Start()
    {
        LoadReplique(firstReponse);
    }

    public void LoadReponse()
    {
        //layoutGroup
        canPass = false;
        foreach (Reponse reponse in _replique.ListReponse)
        {
            GameObject button = Instantiate(buttonPrefab, layoutGroup.transform);

            if (button.TryGetComponent<YesButton>(out YesButton yesbtn))
            {
                yesbtn.InitButton(reponse);
            }
        }
    }

    public void LoadReplique(Reponse reponse)
    {
        if (reponse.win)
        {
            GameManager.Instance.AddReplique();
            SceneAudioPlayer.Instance.AccelerateMusicSpeed();
            ClearLayout();
            _IdReplique = reponse.replique.IdReplique;
            _replique = reponse.replique;
            Timer.Instance.countdown = _replique.repliqueDuration;
            Timer.Instance.currentTimer = _replique.repliqueDuration;
            ShowNextReplique();  
        }
        else
        {
            GameOver();
        }
        
    }

    public void GameOver()
    {
        GameManager.Instance.hasLost = true;
        StartCoroutine(Timer.Instance.GameOver());
    }

    void ShowNextReplique()
    {
        //if (canPass)
        //{
            texteReplique.text = ""; // Effacez le texte existant
            //StopAllCoroutines();
            StopCoroutine(TypeSentence(_replique.text));
            StartCoroutine(TypeSentence(_replique.text));
            LoadReponse();
        //}
    }
    
    IEnumerator TypeSentence(string sentence)
    {
        foreach (char letter in sentence.ToCharArray())
        {
            audioSource.Play();
            float newPitch = Mathf.Clamp(audioSource.pitch, 0.9f, 1.1f);
            audioSource.pitch = newPitch;
            texteReplique.text += letter;
            yield return new WaitForSeconds(typingSpeed * 0.05f);
        }
    }

    public void ClearLayout()
    {
        
        if (layoutGroup.transform.childCount > 0)
        {
            for (int i = layoutGroup.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(layoutGroup.transform.GetChild(i).gameObject);
            }
        }
    }
    
}
    


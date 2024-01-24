using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.UI;
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

    public Replique _replique;
    private int _IdReplique = 0;
    private List<Replique> _ListReplique = new List<Replique>();
    private static DialogueSystem instance = null;
    public static DialogueSystem Instance => instance;

    public AudioSource lettersAudio;
    public AudioSource validateBip;
    public AudioSource missBip;

    public List<GameObject> buttonList = new List<GameObject>();


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


    public void Start()
    {
        LoadReplique(firstReponse);
    }

    public void LoadReponse()
    {
        foreach (Reponse reponse in _replique.ListReponse)
        {
            GameObject button = Instantiate(buttonPrefab, layoutGroup.transform);

            if (button.TryGetComponent<YesButton>(out YesButton yesbtn))
            {
                yesbtn.InitButton(reponse);
            }

            buttonList.Add(button);
        }
    }

    public void LoadReplique(Reponse reponse)
    {
        if (reponse.win)
        {
            validateBip.Play();
            buttonList.Clear();
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
        foreach (GameObject go in buttonList)
            go.GetComponent<Button>().interactable = false;
        missBip.Play();
        GameManager.Instance.hasLost = true;
        StartCoroutine(Timer.Instance.GameOver());
    }

    void ShowNextReplique()
    {
        texteReplique.text = ""; // Effacez le texte existant
        StopAllCoroutines();
        StartCoroutine(TypeSentence(_replique.text));
        LoadReponse();
    }
    
    IEnumerator TypeSentence(string sentence)
    {
        foreach (char letter in sentence.ToCharArray())
        {
            lettersAudio.Play();
            float newPitch = Mathf.Clamp(lettersAudio.pitch, 0.9f, 1.1f);
            lettersAudio.pitch = newPitch;
            texteReplique.text += letter;
            if(GameManager.Instance.hasLost)    
                break;
            yield return new WaitForSeconds(_replique.textSpeed * 0.05f);
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
    


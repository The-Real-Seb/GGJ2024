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

        _ListReplique = new List<Replique>();
        

        Replique[] repliques = Resources.LoadAll<Replique>("Repliques");
        if (repliques != null)
        {
            foreach (var t in repliques)
            {
                _ListReplique.Add(t);
            }
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
            //GameManager.Instance.AddReplique();
            ClearLayout();
            _IdReplique = reponse.replique.IdReplique;
            _replique = reponse.replique;
            Timer.Instance.countdown = _replique.repliqueDuration;
            ShowNextReplique();  
        }
        else
        {
            GameOver();
        }
        
    }

    public void GameOver()
    {
        Timer.Instance.GameOver();
    }

    void ShowNextReplique()
    {
        //if (canPass)
        //{
            texteReplique.text = ""; // Effacez le texte existant
            StopAllCoroutines();
            StartCoroutine(TypeSentence(_replique.text));
            LoadReponse();
        //}
    }
    
    IEnumerator TypeSentence(string sentence)
    {
        foreach (char letter in sentence.ToCharArray())
        {
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
    


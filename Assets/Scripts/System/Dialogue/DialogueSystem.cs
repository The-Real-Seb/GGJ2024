using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField]
    private int _IdReplique = 0;

    [SerializeField]
    private List<Replique> _ListReplique = new List<Replique>();

    public Reponse firstReponse;

    public GameObject layoutGroup;
    public GameObject buttonPrefab;
    public TextMeshProUGUI texteReplique;

    
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            LoadReplique(firstReponse);
        }
    }

    public void LoadReponse()
    {
        //layoutGroup
        
        foreach (Reponse reponse in _ListReplique[_IdReplique].ListReponse)
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
        ClearLayout();
        _IdReplique = reponse.replique.IdReplique;

        Debug.LogWarning("IDReponse : " + reponse.IdReponse);
        Debug.LogWarning("IDReplique : " + _IdReplique);
        
        StartCoroutine(ShowPlayerReplique(reponse));
    }

    IEnumerator ShowPlayerReplique(Reponse reponse)
    {
        string text = reponse.afterText;
        Debug.LogWarning("Text: " + text);
        texteReplique.SetText(text);
        
        yield return new WaitForSeconds(5);
        
        texteReplique.SetText(reponse.replique.text);
        LoadReponse();
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

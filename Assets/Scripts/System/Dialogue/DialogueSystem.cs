using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField]
    private int _LevelReplique;
    [SerializeField]
    private int _LevelReponse;

    [SerializeField]
    private List<Replique> _ListReplique = new List<Replique>();
    [SerializeField]
    private List<Reponse> _ListReponse = new List<Reponse>();

    public GameObject layoutGroup;

    private void Awake()
    {
        _ListReplique = new List<Replique>();
        _ListReponse = new List<Reponse>();

        Replique[] repliques = Resources.LoadAll<Replique>("Repliques");
        if (repliques != null)
        {
            foreach (var t in repliques)
            {
                _ListReplique.Add(t);
            }
        }

        Reponse[] reponses = Resources.LoadAll<Reponse>("Reponses");
        if (reponses != null)
        {
            foreach (var v in reponses)
            {
                _ListReponse.Add(v);
            }
        }
    }

    public void LoadReponse()
    {
        //layoutGroup
    }

    
}

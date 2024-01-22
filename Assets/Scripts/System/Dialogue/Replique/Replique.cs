using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Replique", menuName = "Replique")]
public class Replique : ScriptableObject
{
    public int IdReplique;
    public int _LinkIdReponse;
    public string text;
    public Reponse[] ListReponse;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Replique", menuName = "Replique")]
public class Replique : ScriptableObject
{
    public int IdReplique;
    public string text;
    public float repliqueDuration;
    public float textSpeed;
    public Sprite image;
    public Reponse[] ListReponse;
}

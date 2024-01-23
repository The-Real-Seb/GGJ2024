using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Reponse", menuName = "Reponse")]
public class Reponse : ScriptableObject
{
    public int IdReponse;
    public Replique replique;
    public string text;
    public TMP_FontAsset font;
}

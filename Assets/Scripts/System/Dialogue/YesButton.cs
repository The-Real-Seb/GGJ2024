using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class YesButton : MonoBehaviour
{
    public Reponse reponse;
    public TextMeshProUGUI text;
    private Button _Button;
    private Image _Image;

    
    public void InitButton(Reponse rep)
    {
        reponse = rep;
        text.SetText(rep.text);
        //_Image.sprite = reponse.uiImage.sprite;
    }

    public void onYesClick()
    {
        DialogueSystem.Instance.LoadReplique(reponse);
    }
}

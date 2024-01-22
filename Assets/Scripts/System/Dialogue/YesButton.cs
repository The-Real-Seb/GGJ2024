using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class YesButton : MonoBehaviour
{
    public Reponse reponse;
    private Button _Button;
    private Image _Image;

    public void InitButton()
    {
        _Image.sprite = reponse.uiImage.sprite;
    }
}

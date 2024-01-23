using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;

    public Animator animator;
    public int nbReplique = 0;
    public float timer;//a changer

    public Image currentFace;
    public Image currentTenue;
    
    public Sprite disapointedFace;
    public Sprite basicFace;
    public Sprite smilyFace;
    public Sprite happyFace;
    public Sprite angryFace;
    public bool hasLost;
    
    public Sprite basicTenue;
    public Sprite cartonTenue;
    public Sprite wineTenue;
    

    public void AddReplique()
    {
        nbReplique++;
        CheckSprite();
    }

    private void Start()
    {
        //Arrivée en anim 
        
        currentFace.sprite = disapointedFace;
        //DialogueSystem.Instance.BeginGame();
        CheckSprite();
    }


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
   
    private void CheckSprite()
    {
        switch (nbReplique)
        {
            case 0:
                currentFace.sprite = disapointedFace;
                currentTenue.sprite = basicTenue;
                
                break;
            case 3:
                currentFace.sprite = basicFace;
                break;
            case 6:
                currentFace.sprite = smilyFace;
                currentTenue.sprite = cartonTenue;
                break;
            case 9:
                currentFace.sprite = happyFace;
                break;
            case 13:
                currentFace.sprite = happyFace;
                currentTenue.sprite = wineTenue;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
    
{

    public float bank;
    public Text bankText;

    public static Money instance;

    private void Awake()
    {
    if(instance == null)
        {
            instance = this;
        }        
    }

    private void Start()
    {
        bankText.text = "x " + bank.ToString();
    }

    public void MoneyCollect(float cashCollected)
    {
        bank += cashCollected;
        bankText.text = "x " + bank.ToString();
    }

}

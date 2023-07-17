using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubItems : MonoBehaviour
{
    public Text subItemsText;
    public int subItemsAmount;

    public static SubItems instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        subItemsText.text = "x " + subItemsAmount.ToString();
    }

    public void SubItem(int subItemsAmount)
    {
        subItemsAmount += subItemsAmount;
        subItemsText.text = "x " + subItemsAmount.ToString();
    }

}


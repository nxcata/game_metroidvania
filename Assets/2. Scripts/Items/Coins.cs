using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    public float cashToGive;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Money.instance.MoneyCollect(cashToGive);
            Destroy(gameObject);
        }
    }
}

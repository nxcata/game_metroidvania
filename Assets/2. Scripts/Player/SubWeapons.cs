using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapons : MonoBehaviour
{

    public int HeartCost;
    public GameObject arrow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UseSubWeapon();
    }

    public void UseSubWeapon()
    {
        if (Input.GetButtonDown("Fire2") && HeartCost <= Hearts.instance.HeartsAmount)
        {
            Hearts.instance.SubItem(-HeartCost);
            GameObject subItem = Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, -46));

            if(transform.localScale.x < 0 )
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-700f, 0f), ForceMode2D.Force);
                subItem.transform.localScale = new Vector2(-1, -1);
            }else
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(700f, 0f), ForceMode2D.Force);
            }
            
           
        }
    }
}

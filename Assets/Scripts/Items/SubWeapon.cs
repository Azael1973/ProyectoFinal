using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapon : MonoBehaviour
{
    public int arrowCost;
    public GameObject arrow;

    void Start()
    {
        
    }

    void Update()
    {
        UseSubWeapon();
    }

    public void UseSubWeapon()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            if (arrowCost <= Subitems.instance.subItemsAmount)
            {
                Subitems.instance.SubItem(-arrowCost);
                GameObject subItem = Instantiate(arrow, transform.position, Quaternion.Euler(0,0,-46));
                AudioManager.instance.PlayAudio(AudioManager.instance.arrow);

                if(transform.localScale.x < 0)
                {
                    subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1700f, 0f), ForceMode2D.Force);
                    subItem.transform.localScale = new Vector2(-0.68f, -0.68f);
                }
                else
                {
                    subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(1700f, 0f), ForceMode2D.Force);
                }
            }
        }
    }
}

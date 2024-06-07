using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{
    #region Variables
    public float healthToGive;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<PlayerHealth>().health < collision.GetComponent<PlayerHealth>().maxHealth)
        {
            collision.GetComponent<PlayerHealth>().health += healthToGive;
            Destroy(gameObject);
        }
    }
}

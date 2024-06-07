using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    #region Variables
    public float health;
    public float maxHealth;
    public Image healthImg;
    bool isInmune;
    public float inmunityTime;
    Blink material;
    SpriteRenderer sprite;
    public float knockbackForceX;
    public float knockbackForceY;
    Rigidbody2D rb;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        health = maxHealth;
        material.original = sprite.material;
    }

    private void Update()
    {
        healthImg.fillAmount = health / 100;

        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && !isInmune)
        {
            health -= collision.GetComponent<Enemy>().damageToGive;
            StartCoroutine(Inmunity());

            if(collision.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }

            if(health <= 0 )
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    IEnumerator Inmunity()
    {
        isInmune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(inmunityTime);
        sprite.material = material.original;
        isInmune = false;
    }
}

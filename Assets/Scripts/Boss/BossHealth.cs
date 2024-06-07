using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    #region Variables
    Enemy enemy;
    public Animator anim;
    public bool isDamaged;
    SpriteRenderer sprite;
    Blink material;
    Rigidbody2D rb;
    #endregion

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        material = GetComponent<Blink>();
        enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && !isDamaged)
        {
            enemy.healthPoints -= 2f;

            AudioManager.instance.PlayAudio(AudioManager.instance.enemydeath);

            if (collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }


            StartCoroutine(Damager());
            if (enemy.healthPoints <= 0)
            {
                ExperienceScript.instance.expModifier(GetComponent<Enemy>().experienceToGive);
                SceneManager.LoadScene(3);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Damager()
    {
        isDamaged = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
        sprite.material = material.original;
    }
}

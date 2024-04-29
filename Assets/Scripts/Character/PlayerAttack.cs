using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public BoxCollider2D colAttack;
    public BoxCollider2D downAttackCollider;
    public Rigidbody2D playerRigidbody;
    public Animator animator;
    public float activeTime = 0.2f;
    public float bounceForce = 600f;

    private void Awake()
    {
        colAttack.enabled = false;
        downAttackCollider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !Input.GetKey(KeyCode.S))
        {
            StartCoroutine(ActivateCollider(colAttack, activeTime));

        }
        
        else if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.S))
        {
            StartCoroutine(ActivateCollider(downAttackCollider, activeTime));
        }
    }

    private IEnumerator ActivateCollider(BoxCollider2D collider, float time)
    {
        collider.enabled = true;
        yield return new WaitForSeconds(time);
        collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Spikes") && Input.GetKey(KeyCode.S))
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0);

            playerRigidbody.AddForce(new Vector2(0, bounceForce));
        }
    }
}

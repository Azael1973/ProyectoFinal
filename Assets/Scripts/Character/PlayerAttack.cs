using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Variables
    public Animator anim;
    public BoxCollider2D downAttackCollider;
    public float activeTime = 0.3f;
    public Rigidbody2D playerRigidbody;
    public float bounceForce = 600f;
    #endregion

    private void Update()
    {
        Attack();
    }

    #region Metodos Ataque
    public void Attack()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetBool("Attack", true);
            AudioManager.instance.PlayAudio(AudioManager.instance.melee);
        }
        else
        {
            anim.SetBool("Attack", false);
            anim.SetBool("DownAttack", false);
        }
    }
    #endregion
}

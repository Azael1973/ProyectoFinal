using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class BossBehavior : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject projectile;

    public float timeToShoot, countdown;
    public float timeToTP, TPcountdown;
    public float bossHealth, currentHealth;
    public Image healthImg;

    private void Start()
    {
        var InitialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[InitialPosition].position;
        countdown = timeToShoot;
        TPcountdown = timeToTP;
    }

    private void Update()
    {
        Countdowns();

        DamageBox();

        BossScale();
    }
    
    public void Countdowns()
    {
        countdown -= Time.deltaTime;
        TPcountdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            ShootPlayer();
            countdown = timeToShoot;
        }

        if (TPcountdown <= 0)
        {
            TPcountdown = timeToTP;
            Teleport();
        }
    }

    public void ShootPlayer()
    {
        GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
    }

    public void Teleport()
    {
        var InitialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[InitialPosition].position;
    }

    public void DamageBox()
    {
        currentHealth = GetComponent<Enemy>().healthPoints;
        healthImg.fillAmount = currentHealth / 50;
    }

    public void BossScale()
    {
        if (transform.position.x > PlayerMovement.Instance.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}

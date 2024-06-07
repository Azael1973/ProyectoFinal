using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.TextCore.Text;

public class BossActivate : MonoBehaviour
{
    public GameObject bossGO;
    public CinemachineVirtualCamera bossCamera;
    public Camera mainCamera;

    private void Start()
    {
        bossGO.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BossUI.instance.BossActivator();
            bossGO.SetActive(true);
        }
    }
}

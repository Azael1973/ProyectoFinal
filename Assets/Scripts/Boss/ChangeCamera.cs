using Cinemachine;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public CinemachineVirtualCamera mainCamera;
    public CinemachineVirtualCamera bossCamera;
    public GameObject background;
    public GameObject backgroundBoss;

    private void Start()
    {
        if (mainCamera != null)
        {
            mainCamera.gameObject.SetActive(true);
        }

        if (bossCamera != null)
        {
            bossCamera.gameObject.SetActive(false);
        }

        if (background != null)
        {
            background.SetActive(true);
        }

        if (backgroundBoss != null)
        {
            backgroundBoss.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (mainCamera != null && bossCamera != null)
            {
                mainCamera.gameObject.SetActive(false);
                bossCamera.gameObject.SetActive(true);
            }

            if (background != null && backgroundBoss != null)
            {
                background.SetActive(false);
                backgroundBoss.SetActive(true);
            }
        }
    }
}

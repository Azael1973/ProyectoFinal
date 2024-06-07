using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Keys : MonoBehaviour
{
    public int keyCount = 0;
    public Tilemap doorTilemap;

    void Start()
    {
        if (doorTilemap != null)
        {
            doorTilemap.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            
            keyCount++;

            if (keyCount >= 2)
            {
                if (doorTilemap != null)
                {
                    doorTilemap.gameObject.SetActive(false);
                    AudioManager.instance.PlayAudio(AudioManager.instance.door);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour
{
    public Transform player;
    public float xpos;
    public float ypos;
    public float zpos;

    private void Start()
    {
        transform.position = new Vector3(player.position.x + xpos, player.position.y + ypos, zpos);
    }

    private void Update()
    {
        transform.position = new Vector3(player.position.x + xpos, player.position.y + ypos, zpos);
    }
}

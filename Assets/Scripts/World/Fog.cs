using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float offset;
    [SerializeField] private GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && collision.isTrigger)
        {
            Debug.Log(collision.name + " entered fog");

            float playerX = player.transform.position.x * x;
            float playerY = player.transform.position.y * y;

            if(x == -1)
                player.transform.position = new Vector3(playerX + offset, playerY, 0f);
            else
                player.transform.position = new Vector3(playerX, playerY + offset, 0f);
        }
    }
}

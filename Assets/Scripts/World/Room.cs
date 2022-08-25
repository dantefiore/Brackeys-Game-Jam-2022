using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private CinemachineConfiner vCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.isTrigger)
        {
            //vCam.SetActive(true);
            vCam.m_BoundingShape2D = this.GetComponent<PolygonCollider2D>();
        }
    }
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.isTrigger)
            vCam.m_BoundingShape2D = null;
    }*/
}

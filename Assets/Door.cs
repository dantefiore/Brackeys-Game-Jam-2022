using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject other;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && col.isTrigger)
        {
            Debug.Log("This worked");
            SceneManager.LoadScene("TherapyScene");
        }
    }
}

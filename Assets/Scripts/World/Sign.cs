using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject nextSign;


    //[SerializeField] private GameObject thisSign;
    /*[SerializeField] private GameObject nextSign;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            StartCoroutine(DisapperSign());
    }

    private IEnumerator DisapperSign()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
        nextSign.SetActive(true);
    }*/

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            nextSign.SetActive(true);
        }
    }
}

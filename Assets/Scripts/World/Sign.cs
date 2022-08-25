using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    //[SerializeField] private GameObject thisSign;
    [SerializeField] private GameObject nextSign;

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
    }
}

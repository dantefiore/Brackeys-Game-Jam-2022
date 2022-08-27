using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signChooser : MonoBehaviour
{

    public GameObject sign1;
    public GameObject sign2;
    public GameObject sign3;
    public GameObject sign4;

    // Start is called before the first frame update
    void Start()
    {
        float randomNumber = Random.Range(0, 3);

        sign1.SetActive(false);
        sign2.SetActive(false);
        sign3.SetActive(false);
        sign4.SetActive(false);

        switch (randomNumber)
        {
            case 0f:
                sign1.SetActive(true);
                break;
            case 1f:
                sign2.SetActive(true);
                break;
            case 2f:
                sign3.SetActive(true);
                break;
            case 3f:
                sign4.SetActive(true);
                break;
        }
    }

}

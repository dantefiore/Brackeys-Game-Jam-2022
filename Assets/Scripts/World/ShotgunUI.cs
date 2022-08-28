using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunUI : MonoBehaviour
{
    [Header("Enemy SO")]
    [SerializeField] private IntVal smoke;
    [SerializeField] private IntVal alc;
    [SerializeField] private IntVal lust;

    [Header("X Images")]
    [SerializeField] private Image x1;
    [SerializeField] private Image x2;
    [SerializeField] private Image x3;

    private void Update()
    {
        if (smoke.currentVal <= 0)
            x1.gameObject.SetActive(true);

        if (alc.currentVal <= 0)
            x2.gameObject.SetActive(true);

        if (lust.currentVal <= 0)
            x3.gameObject.SetActive(true);
    }

}

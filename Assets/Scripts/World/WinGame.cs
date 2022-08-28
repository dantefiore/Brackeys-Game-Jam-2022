using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject lvlLoader;

    [Header("IntVals")]
    [SerializeField] private IntVal smoke;
    [SerializeField] private IntVal alc;
    [SerializeField] private IntVal lust;

    // Update is called once per frame
    void Update()
    {
        if(smoke.currentVal <= 0 && alc.currentVal <= 0 && lust.currentVal <= 0)
            lvlLoader.GetComponent<LevelChanger3>().FadeToLevel(6);
    }
}

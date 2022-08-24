using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private List<Transform> firePoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject temp;
    private Transform tempRot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        for(int i=0; i < firePoint.Count; i++)
        {
            Instantiate(bullet, firePoint[i].position, firePoint[i].rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Gun : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private List<Transform> firePoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Animator cameraShake;

    private void Start()
    {
        cameraShake = cameraShake.gameObject.GetComponent<Animator>();
    }

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

        cameraShake.SetTrigger("shake");
        //CameraShake.Instance.Shake(magnitude, duration);
    }
}

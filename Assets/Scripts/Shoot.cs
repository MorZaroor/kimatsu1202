using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}

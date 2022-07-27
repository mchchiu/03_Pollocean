using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointScript : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    // Update is called once per frame
    // void FixedUpdate()
    // {
    //     // if (Input.GetButtonDown("Fire1"))
    //     // {
    //         // StartCoroutine(ShootCoroutine());
    //     // }
    // }

    void shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }

    IEnumerator ShootCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            shoot();
        }
    }
}

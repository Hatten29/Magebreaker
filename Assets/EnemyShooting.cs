using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    public float timer;

    void Start()
    {
        
    }

    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            shoot();
        }

        void shoot()
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunController : MonoBehaviour
{

    //Bullet
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 6f;
    public float bulletDistance = 2f;
    public float rateOfFire = 1f;

    private bool canFire;
    public bool CanFire
    {
        get { return canFire; }
        set { canFire = value; }
    }

    public void Rotate(float rotation_z, float offset)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
    }

    public void  Fire()
    {
        print("Fire by GC");
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<>
        // Destroy the bullet after 2 seconds
        Destroy(bullet, bulletDistance);
    }

}

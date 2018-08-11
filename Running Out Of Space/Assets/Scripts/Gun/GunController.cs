using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunController : MonoBehaviour
{

    public float rateOfFire;
    public float bulletStrength;

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


    private void Update()
    {
        if (canFire)
            Fire();
    }

    public void Fire()
    {
        print("Fire by GC");
    }

}

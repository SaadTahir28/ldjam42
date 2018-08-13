using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GunController gunController;

    public float moveSpeed;
    private float gun_rotation_offset; //perfectly on mouse

    private void Awake()
    {
        gun_rotation_offset = Constants.player_gun_rotation_offset;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        GunRotation();
        GunFire();
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //moves upward
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            //moves downward
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //moves left
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //moves right
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
    }
    private void GunRotation()
    {
        float zPos = CalculateZPosition();
        gunController.Rotate(zPos, gun_rotation_offset);
    }
    private void GunFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Start Fire by PC");
            gunController.Fire();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            print("Stop Fire by PC");
            gunController.CanFire = false;
        }
    }

    private float CalculateZPosition()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        return rotation_z;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            print("Collided with Enemy");
        }
        else if (collision.gameObject.tag == "Space")
        {
            print("Collided with Space");
        }
        else if (collision.gameObject.tag == "Collectable")
        {
            print("Collided with Collectable");
        }
    }

}

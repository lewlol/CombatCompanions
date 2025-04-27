using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Gun gun;

    //Variables
    bool canShoot;
    Camera cam;

    private void Awake()
    {
        canShoot = true;
        cam = Camera.main;
    }

    private void Update()
    {
        if (canShoot)
        {
            //Player Can Shoot a Bullet
              //Detect whether the gun is Automatic or not
            if (gun.automatic)
            {
                //Button Input (without Down = Automatic)
                if (Input.GetMouseButton(0))
                {
                    ShootBullet(); //Shoot Bullet
                    StartCoroutine(ShootTimer()); //Shoot Timer
                }
            }
            else
            {
                //Button Input (with Down = not Automatic)
                if (Input.GetMouseButtonDown(0))
                {
                    ShootBullet(); //Shoot Bullet
                    StartCoroutine(ShootTimer()); //Shoot Timer
                }
            }
        }
    }

    private void ShootBullet()
    {
        //Get Mouse Location
        RaycastHit hit;
        Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit);

        //Determine Bullet Direction
        Vector3 bulletDir = hit.point - transform.position;
        bulletDir.y = transform.position.y;

        //Instantiate Bullet
        GameObject newBullet = Instantiate(gun.bullet, transform.position, Quaternion.identity);

        //Add Variables to Bullet
        newBullet.GetComponent<Rigidbody>().AddForce(bulletDir.normalized * gun.bulletSpeed, ForceMode.Impulse);
        newBullet.GetComponent<Bullet>().damage = gun.damage;

        //Destroy Bullet
        Destroy(newBullet, gun.bulletTime);
    }

    IEnumerator ShootTimer()
    {
        canShoot = false;
        yield return new WaitForSeconds(gun.shootDelay);
        canShoot = true;
    }
}

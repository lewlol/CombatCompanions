using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    bool dead;
    public bool canShoot;
    Camera cam;

    public Gun gun;

    private void Start()
    {
        PlayerEvents.playerEvent.onPlayerDied += PlayerDied;
        canShoot = true;
        cam = Camera.main;
    }

    private void Update()
    {
        if (dead)
            return;

        if (gun.automatic)
        {
            if (Input.GetMouseButton(0) && canShoot)
            {
                ShootBullet();
                StartCoroutine(CanShootBullet());
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                ShootBullet();
                StartCoroutine(CanShootBullet());
            }
        }
    }

    private void ShootBullet()
    {
        Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();

        GameObject newBullet = Instantiate(gun.bulletOBJ, transform.position, Quaternion.identity);

        Vector2 bulletAccuracy = new Vector2(Random.Range(-gun.accuracy, gun.accuracy), Random.Range(-gun.accuracy, gun.accuracy));
        newBullet.GetComponent<Rigidbody2D>().linearVelocity = (direction + bulletAccuracy) * gun.bulletSpeed;
        newBullet.GetComponent<Bullet>().damage = gun.damage;

        Destroy(newBullet, gun.bulletLifetime);
    }

    IEnumerator CanShootBullet()
    {
        canShoot = false;
        yield return new WaitForSeconds(gun.attackDelay);
        canShoot = true;
    }

    public void PlayerDied()
    {
        dead = true;
    }
}

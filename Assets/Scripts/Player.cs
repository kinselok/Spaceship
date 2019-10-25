using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHitAsteroid
{
    public static readonly float cooldown = 5f;
    bool CanIShoot = true;
    public GameObject Bullet;
    public void Hit()
    {
        UIController.instance.EndGame();
        Time.timeScale = 0;
    }

    void Fire()
    {
        if (CanIShoot)
        {
            Vector3 pos = new Vector3(transform.position.x, Bullet.transform.position.y, 0);
            Instantiate(Bullet, pos, Quaternion.identity);
            Reload();
        }
    }
    void Reload()
    {
        CanIShoot = false;
        UIController.instance.StartCooldown(cooldown);
        Invoke("EnableFire", cooldown);
    }
    void EnableFire()
    {
        CanIShoot = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) Fire();
        float x = Input.acceleration.x;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(x * 40, 0, 0);
    }
}

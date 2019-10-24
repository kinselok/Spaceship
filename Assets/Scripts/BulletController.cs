using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : MonoBehaviour, IHitAsteroid
{
    const float speed = 40f;

    public void Hit()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 40f);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, speed, 0);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IHitAsteroid
{
    void Hit();
}
public class AsteroidController : MonoBehaviour
{
    float size;
    
    
    // Start is called before the first frame update
    void Start()
    {
        size = Random.Range(2f, 4f);
        transform.localScale = new Vector3(size, size, size);
        
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -GameController.Speed, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHitAsteroid obj))
        {           
            obj.Hit();
            GameController.Score += size;
            Destroy(gameObject);
        }
        
    }
}

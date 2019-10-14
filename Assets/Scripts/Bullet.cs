using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11) //11: Platforms
        {
            Instantiate(hitFX, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }

    }
}   


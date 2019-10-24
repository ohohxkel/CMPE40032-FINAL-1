using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class EnemyShoots : MonoBehaviour {
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform Player;

    private float rotateY;
    public int scoreValue;
    public GameObject lootDrop, hitFX;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

   
    // Update is called once per frame
    void Update()
    {
        //Flips enemies
        if (player.transform.position.x < transform.position.x)
        {
            rotateY = 180f;
        }

        else if (player.transform.position.x > transform.position.x)
        {
            rotateY = 0f;
        }
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, rotateY, transform.rotation.z));




        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        
        if(timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(hitFX, transform.position, transform.rotation);
            StartCoroutine(Camera.main.GetComponent<CamShake>().Shake(0.5f, 0.5f));
            ScoreManager.score += scoreValue;
            Destroy(gameObject);
            //Instantiate(lootDrop, transform.position, Quaternion.identity);
        }
    }

}







using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyFollow : MonoBehaviour
{
    public MoveCharacter thePlayer;
    public GameObject hitFX;

    public float moveSpeed;
    public float playerRange;
    float newX, newY, rotateY;
    public int scoreValue = 10;

    public LayerMask layer;

    public bool playerInRange;
    bool bumpedRight, bumpedLeft;

    public GameObject lootDrop;



    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<MoveCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        // Detects if the player is in range of the drawn circle
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, layer);

        if (playerInRange)
        {
            //Moves toward the player if inrange
            moveSpeed += 2 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);

            //Flips enemies
            if (thePlayer.transform.position.x < transform.position.x)
            {
                rotateY = 180f;
            }

            else if(thePlayer.transform.position.x > transform.position.x)
            {
                rotateY = 0f;
            }
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, rotateY, transform.rotation.z));
        }

        else
        {
            if (transform.position.y > 3.0f)
            {
                newY = transform.position.y - moveSpeed * Time.deltaTime;
            }

            else if (bumpedRight)
            {
                newX = transform.position.x - moveSpeed * Time.deltaTime;
                rotateY = 180f;
                
            }

            else if (bumpedLeft)
            {
                newX = transform.position.x + moveSpeed * Time.deltaTime;
                rotateY = 0f;
            }

            else
            {
                newX = transform.position.x + moveSpeed * Time.deltaTime;
            }
            transform.position = new Vector3(newX, newY);
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, rotateY, transform.rotation.z));
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draws circle acting as a checkpoint
        Gizmos.DrawSphere(transform.position, playerRange);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            CameraShaker.Instance.ShakeOnce(3f, 3f, .7f, .7f);
            Instantiate(hitFX, transform.position, transform.rotation);
            ScoreManager.score += scoreValue;
            Destroy(gameObject);
            Instantiate(lootDrop, transform.position, Quaternion.identity);
        }

        else if (collision.gameObject.tag == "RightWall")
        {
            bumpedRight = true;
            Debug.Log("Enemy Bumped to Right Wall");
        }

        else if (collision.gameObject.tag == "LeftWall")
        {
            bumpedLeft = true;
            Debug.Log("Enemy Bumped to Left Wall");
        } 
    }




}


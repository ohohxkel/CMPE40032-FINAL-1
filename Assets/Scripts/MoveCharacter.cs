

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public GameObject PlayerHitFX;
    public pointbullet pointBullet;

    public float addMana = 5f;



    // Update is called once per frame
    void Update()
    {



        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("HorizontalMove", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Vertical"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Vertical"))
        {
            crouch = false;
        }

       

        if (PlayerHealth.health <= 0f)
        {
            Instantiate(PlayerHitFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }

     

    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(PlayerHitFX, transform.position, Quaternion.identity);
            PlayerHealth.health -= 10f;
        }

     

        else if (collision.gameObject.tag == "Item")
        {
            PlayerMana.mana += addMana;
            pointBullet.ChangeBullet(2);
            Destroy(collision.gameObject);
        }
    }
}



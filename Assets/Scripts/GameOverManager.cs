using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    Animator anim;
    
    public PlayerHealth health;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        //Test variable
        if (PlayerHealth.health == 0f)
        {
            anim.SetTrigger("GameOver");
            Debug.Log("Game Over");
        }
    }


}

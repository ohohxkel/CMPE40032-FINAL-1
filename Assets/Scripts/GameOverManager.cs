using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    Animator anim;
    public ScoreManager score;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        //Test variable
        if (ScoreManager.score == 10)
        {
            anim.SetTrigger("GameOver");
            Debug.Log("Game Over");
        }
    }


}

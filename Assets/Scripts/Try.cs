using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Try : MonoBehaviour
{

    public GameObject Asteroid;

    private float min_X = -7.37f;
    private float max_X = 7.37f;


    // Start is called before the first frame update
    void Start()
    {
    StartCoroutine(StartSpawning());
    }


    IEnumerator StartSpawning()
    {
    yield return new WaitForSeconds(Random.Range(1, 2));

    GameObject k = Instantiate(Asteroid);

    float x = Random.Range(min_X, max_X);

    k.transform.position = new Vector2(x, 7.25f);

    StartCoroutine(StartSpawning());

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}

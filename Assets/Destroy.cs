using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    float time = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyFX());
    }

    // Update is called once per frame
    IEnumerator DestroyFX()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}

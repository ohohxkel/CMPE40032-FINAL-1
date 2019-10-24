using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointbullet: MonoBehaviour
{
    public GameObject cross;
    public GameObject player;
    public GameObject bulletStart;
    public GameObject bulletPrefab;

    public GameObject bulletLvl1;
    public GameObject bulletLvl2;

    public static int bulletLvl, bulletLevel;

    public float bulletSpeed = 10.0f;
    public AudioSource backgroundMusic;

    private Vector3 target;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        backgroundMusic.Play();
        backgroundMusic.loop = true;

    }
    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        cross.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            switch (bulletLevel)
            {
                case 1:
                    bulletPrefab = bulletLvl1;
                    break;
                case 2:
                    bulletPrefab = bulletLvl2;
                    break;
                default:
                    bulletPrefab = bulletLvl1;
                    break;
            }
            if (PlayerMana.mana > 0)
            {
                fireBullet(direction, rotationZ, bulletPrefab);
            }
        }
    }
    void fireBullet(Vector2 direction, float rotationZ, GameObject bulletPrefab)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        PlayerMana.mana -= 10f;
    }

    public void ChangeBullet  (int bulletLvl)
    {
        bulletLevel = bulletLvl;
    }
}

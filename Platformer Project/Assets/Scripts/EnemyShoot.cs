using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject prefab;
    public float Bulletspeed = 5.0f;
    public float bulletLifetime = 2.0f;
    public GameObject player;
    public float close = 5.0f;
    public float shootDelay = 1.0f;
    float timer = 0;
    public AudioClip fireball;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 shootDir = player.transform.position - transform.position;
        float shootDist = shootDir.magnitude;
        shootDir.Normalize();
        if (shootDist <= close)
        {
            if(timer >= shootDelay)
            {
                //shoot
                timer = 0;

                GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = shootDir * Bulletspeed;
                Destroy(bullet, bulletLifetime);
                Camera.main.GetComponent<AudioSource>().PlayOneShot(fireball);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(prefab);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
    public float bulletSpeed = 3f;
    public Rigidbody2D bulletRB;
    public int bulletDammage;
    public ParticleSystem bulletHitEffect;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {if (collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<status>().TakeDammage(bulletDammage);
            Instantiate(bulletHitEffect, transform.position, Quaternion.identity);
            bulletHitEffect.Play();
            Destroy(gameObject);
        }
        else {
            Instantiate(bulletHitEffect, transform.position, Quaternion.identity);
            bulletHitEffect.Play();
            Destroy(gameObject);
             }
    }
}

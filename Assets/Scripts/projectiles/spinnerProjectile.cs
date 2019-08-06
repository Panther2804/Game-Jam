using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinnerProjectile : MonoBehaviour
{
    public int bulletDammage;
    public ParticleSystem bulletHitEffect;
    private Transform player;
    private Vector2 target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x==target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<status>().TakeDammage(bulletDammage);
            Instantiate(bulletHitEffect, transform.position, Quaternion.identity);
            bulletHitEffect.Play();
            Destroy(gameObject);
        }
        else
        {
            if (collision.gameObject != GameObject.FindGameObjectWithTag("enemy"))
            {
                Instantiate(bulletHitEffect, transform.position, Quaternion.identity);
                bulletHitEffect.Play();
                Destroy(gameObject);
            }
        }
    }
    void DestroyProjectile()
    {
        Instantiate(bulletHitEffect, transform.position, Quaternion.identity);
        bulletHitEffect.Play();
        Destroy(gameObject);
    }
}

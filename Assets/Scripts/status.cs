using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status : MonoBehaviour
{
    public int health;
    public ParticleSystem deathParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(health<=0)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            deathParticle.Play();
            Destroy(gameObject);
        }
    }
    public void TakeDammage(int amount)
    {
        health -= amount;
    }
}

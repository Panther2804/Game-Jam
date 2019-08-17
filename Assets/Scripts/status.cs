using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status : MonoBehaviour
{
    public  ExperienceSystem XPke; 
    public int health;
    public ParticleSystem deathParticle;
    

    // Start is called before the first frame update
    void Start()
    {
        XPke = GameObject.FindGameObjectWithTag("xpSystem").GetComponent<ExperienceSystem>();
    }

    // Update is called once per frame
    void Update()
    {
     if(health<=0)
        {
            
            Die();
        }
    }
    public void TakeDammage(int amount)
    {
        health -= amount;
        
    }
    public virtual void Die()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        deathParticle.Play();
        Destroy(gameObject);
        XPke.UpdateEx(100);
    }
    public virtual IEnumerator Wait() { yield return new WaitForSeconds(2); }
}

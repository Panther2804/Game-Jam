using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status : MonoBehaviour
{
    public ExperienceSystem XPke; 
    public int health;
    public ParticleSystem deathParticle;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        XPke = camera.GetComponent<ExperienceSystem>();
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
        Debug.Log(health);
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

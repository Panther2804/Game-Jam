using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggerSuicide : MonoBehaviour
{ public int damage;
    public ParticleSystem deathPart;
    private Animator anim;
    private Animator PlayerAnim;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        PlayerAnim.SetTrigger("stun");
        anim = GetComponent<Animator>();
        StartCoroutine(wait());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator wait()
    {
        anim.SetTrigger("suicide");
        yield return new WaitForSeconds(2);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovemnt2>().enabled = true;
        Instantiate(deathPart, transform.position, Quaternion.identity);
        deathPart.Play();
        GameObject.FindGameObjectWithTag("Player").GetComponent<status>().TakeDammage(damage);
       
        
       
        Destroy(gameObject);







    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggerSuicide : MonoBehaviour
{ public int damage;
    public ParticleSystem deathPart;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        Instantiate(deathPart, transform.position, Quaternion.identity);
        deathPart.Play();
        
       
        Destroy(gameObject);







    }
}

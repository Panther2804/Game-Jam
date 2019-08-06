using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shellPieces : MonoBehaviour
{ public ParticleSystem deathpart;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(death());
    }
    // Update is called once per frame
    void Update()
    {
       
    }
   public IEnumerator death()
        {
        yield return new WaitForSeconds(3f);
        Instantiate(deathpart, transform.position, Quaternion.identity);
        Destroy(gameObject);
        }
}

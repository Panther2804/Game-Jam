using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crobot : status
{ public GameObject husk;
    public Animator anim;
    private bool died;
    public Transform huskSpawn;
    // Start is called before the first frame update
    void Start()
    {
        died = false;
        anim = GetComponent<Animator>();
        XPke = GameObject.FindGameObjectWithTag("xpSystem").GetComponent<ExperienceSystem>();

    }

    // Update is called once per frame
    
     public override  void Die()
    { //damit nicht mehr part spawnen
        if (died == false)
        {
            died = true;
            Debug.Log("ItsFuckingWorking");
            Instantiate(deathParticle, transform.position, Quaternion.identity);

            deathParticle.Play();
            anim.SetTrigger("die");
            StartCoroutine(Wait());
            XPke.UpdateEx(100);
        }
    }
    public override IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        Instantiate(husk, huskSpawn.position, Quaternion.identity);
        Destroy(gameObject);
    }
    //warte damit die deathanim spielen kann

}

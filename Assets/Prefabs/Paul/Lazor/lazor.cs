using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazor : MonoBehaviour
{


    public Vector3 laserHit;
    public GameObject LazerBeam;
    private Vector3 prevHit;
    public LayerMask Lm;
    public int timeoff;
    public int timeon;
    private int timer;
    public bool ison;
    GameObject beam = null;
    private Animator anim;
    //public GameObject beam;





    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer > timeoff - (1.6 * 60))
        {
            anim.SetBool("shooting", true);

        }

        if (timer > timeoff)
        {


            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, 100f, Lm);
            Debug.DrawLine(transform.position, hit.point);
            laserHit = hit.point;
            laserHit = (transform.position + laserHit) / 2;

            if (prevHit != laserHit)
            {

                Destroy(beam);
                Debug.Log("New Beam @" + laserHit);
                beam = (GameObject)Instantiate(LazerBeam, laserHit, transform.rotation);
                Debug.Log("created beam");
                prevHit = laserHit;
                beam.transform.localScale = new Vector3(hit.distance, 1, 1);


            }



        }


        timer++;
        if (timer > timeoff + timeon)
        {
            timer = 0;
            Destroy(beam);
            Debug.Log("destroyed beam");
            prevHit = new Vector3(0,0,0);
            anim.SetBool("shooting", false);
        }





    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public Animator playerAnim;
    public Transform firepoint;
    public GameObject bullet;
    public ParticleSystem ShotParticle;
    public float StartTimeBTWshot;
    private float TimeBTWshot;
    // Start is called before the first frame update
    void Start()
    {
        TimeBTWshot = StartTimeBTWshot;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (TimeBTWshot <= 0)
            {
                Shoot();
                TimeBTWshot = StartTimeBTWshot;
            }
        }
        TimeBTWshot -= Time.deltaTime;
    }

    void Shoot()
    {
        playerAnim.SetTrigger("attack");
        Instantiate(bullet, firepoint.position, firepoint.rotation);
        Instantiate(ShotParticle, firepoint.position, firepoint.rotation);
        ShotParticle.Play();
    }

}

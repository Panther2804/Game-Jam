using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinnerBehavior : MonoBehaviour
{
    public float StopdistanceBTWcharacter;
    public float StartdistanceBTWcharacter;
    private Transform Target;
    public float speed;
    public GameObject projectile;
    public Transform projectileSpawn;
    public float StartTimeBTW;
    private float TimeBTW;
    //shooting effects
    public Transform shootPartPos;
    public ParticleSystem shootPart;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        TimeBTW = StartTimeBTW;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, Target.position) >= StopdistanceBTWcharacter &&
            Vector2.Distance(transform.position, Target.position) <= StartdistanceBTWcharacter)
        {//wärend er in range ist schießt er
            if (TimeBTW <= 0) { shoot(); TimeBTW = StartTimeBTW; }

            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
        }
        //stehen bleiben
        else if (Vector2.Distance(transform.position, Target.position) <= StopdistanceBTWcharacter)
        {
            if (TimeBTW <= 0) { shoot(); TimeBTW = StartTimeBTW; }
            transform.position = this.transform.position;

        }
        else if (Vector2.Distance(transform.position, Target.position) >= StartdistanceBTWcharacter)
        {
            transform.position = this.transform.position;

        }
        TimeBTW -= Time.deltaTime;
    
}
    void shoot()
    {
        Instantiate(shootPart, shootPartPos.position, Quaternion.identity);
        shootPart.Play();
        Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
    }
}

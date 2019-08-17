using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crobotBehavior : MonoBehaviour
{
    public float StopdistanceBTWcharacter;
    public float StartdistanceBTWcharacter;
    private Transform Target;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {//speicher spieler position
        
        Target = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Target.position) >= StopdistanceBTWcharacter &&
            Vector2.Distance(transform.position, Target.position) <= StartdistanceBTWcharacter)
        {
            transform.position = Vector2.MoveTowards(transform.position,Target.position,speed*Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, Target.position) <= StopdistanceBTWcharacter)
        {
            transform.position = this.transform.position;

        }
        else if (Vector2.Distance( transform.position, Target.position) >= StartdistanceBTWcharacter)
        {
            transform.position = this.transform.position;

        }
    }
}

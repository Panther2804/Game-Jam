using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int OpeningDirection;
    private RoomTemplates templates;
    private int rand;
    public bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", .2f);

    }

    // Update is called once per frame
    void Spawn()
    {
        

        if (spawned == false)
        {
            if (OpeningDirection == 2)
            {
                rand = Random.Range(0, templates.BottomRooms.Length);
                Instantiate(templates.BottomRooms[rand], transform.position - new Vector3(-1,8,0), templates.BottomRooms[rand].transform.rotation);
                //Debug.Log("Created " + templates.BottomRooms[rand].name + " at " + transform.position);
            }
            else if (OpeningDirection == 1)
            {
                rand = Random.Range(0, templates.TopRooms.Length);
                Instantiate(templates.TopRooms[rand], transform.position - new Vector3(-1, 8,0) , templates.TopRooms[rand].transform.rotation);
               // Debug.Log("Created " + templates.TopRooms[rand].name + " at " + transform.position);
            }
            else if (OpeningDirection == 4)
            {
                rand = Random.Range(0, templates.LeftRooms.Length);
                Instantiate(templates.LeftRooms[rand], transform.position - new Vector3(-1, 8,0), templates.LeftRooms[rand].transform.rotation);
                //Debug.Log("Created " + templates.LeftRooms[rand].name + " at " + transform.position);
            }
            else if (OpeningDirection == 3)
            {
                rand = Random.Range(0, templates.RightRooms.Length);
                Instantiate(templates.RightRooms[rand], transform.position - new Vector3(-1, 8,0) , templates.RightRooms[rand].transform.rotation);
               //Debug.Log("Created " + templates.RightRooms[rand].name + " at " + transform.position);
            } else if (OpeningDirection == 5)
            {
                rand = Random.Range(0, templates.StartRooms.Length);
                Instantiate(templates.StartRooms[rand], transform.position - new Vector3(-1, 8, 0), templates.StartRooms[rand].transform.rotation);
                //Debug.Log("Created " + templates.StartRooms[rand].name + " at " + transform.position);
            }
            spawned = true;
        }
    }


    void OnDrawGizmos()
    {
        if(spawned)
        Gizmos.DrawIcon(transform.position, "placerholdergreen.png", true);
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Spawnpoint") && collision.GetComponent<RoomSpawner>().spawned == true) {
            Destroy(gameObject);
            spawned = true;
        }
    }

    */

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spawnpoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                rand = Random.Range(0, templates.ClosedRooms.Length);
                Instantiate(templates.ClosedRooms[rand], transform.position - new Vector3(-1, 8, 0), templates.ClosedRooms[rand].transform.rotation);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }


}

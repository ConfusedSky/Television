using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PathFolower : MonoBehaviour
{
    public GameObject[] path;
    public float speed = 10;
    public float sensitivity = .01f;

    private int index = 0;
    GameObject player = null;

    private bool move = false;

    void FixedUpdate()
    {
        GameObject target = path[index];
        if (move)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

            if (player)
                player.transform.position += newPosition - transform.position;

            transform.position = newPosition;
        }

        if(Vector3.Distance(target.transform.position, transform.position) < sensitivity )
        {
            index++;

            if(index >= path.Length)
            {
                index = 0;
            }
        }
    }

    void OnTriggerEnter(Collider c)
    {
        Debug.Log("Collided with " + c);
        if( c.gameObject.tag == "Player")
        {
            player = c.gameObject;
            move = true;
        }
    }

    void OnTriggerExit(Collider c)
    {
        player = null;
    }
}

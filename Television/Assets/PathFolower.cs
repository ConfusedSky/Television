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
    CharacterController cc = null;

    private bool move = false;
    private bool exited = false;

    void FixedUpdate()
    {
        GameObject target = path[index];
        if (move)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

            if (player)
            {
                player.transform.position += newPosition - transform.position;
                if(exited && cc.isGrounded)
                {
                    player = null;
                }
            }

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
            cc = player.GetComponent<CharacterController>();
            move = true;
            exited = false;
        }
    }

    void OnTriggerExit(Collider c)
    {
        exited = true;
    }

    void OnDrawGizmos()
    {
        foreach (GameObject g in path)
        {
            Gizmos.matrix = Matrix4x4.TRS(g.transform.position, g.transform.rotation, g.transform.lossyScale);
            Gizmos.DrawWireCube(new Vector3(), gameObject.transform.localScale);
        }
    }
}

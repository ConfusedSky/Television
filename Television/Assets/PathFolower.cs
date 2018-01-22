using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PathFolower : MonoBehaviour
{
    public GameObject[] path;
    public float speed = 10;
    public float sensitivity = .01f;

    public int index = 0;
    GameObject player = null;
    CharacterController cc = null;

    public bool move = false;
    private bool exited = false;
    private float rotationSpeed = 0f;

    void FixedUpdate()
    {
        GameObject target = path[index];
        if (move)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, rotationSpeed * Time.deltaTime);

            if (player)
            {
                player.transform.position += newPosition - transform.position;
                if(exited && cc.isGrounded)
                {
                    player = null;
                }
            }

            transform.position = newPosition;
            transform.rotation = newRotation;
        }

        if(Vector3.Distance(target.transform.position, transform.position) < sensitivity )
        {
            int startingIndex = index;
            index++;

            if(index >= path.Length)
            {
                index = 0;
            }

            float distance = (path[index].transform.position - path[startingIndex].transform.position).magnitude / speed;
            rotationSpeed = Mathf.Abs(Mathf.Abs(path[index].transform.rotation.eulerAngles.y - path[startingIndex].transform.rotation.eulerAngles.y)-180)/distance;
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
            Gizmos.matrix = g.transform.localToWorldMatrix;
            Gizmos.DrawWireCube(new Vector3(), gameObject.transform.localScale);
        }
    }
}

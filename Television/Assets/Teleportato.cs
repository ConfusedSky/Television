using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Teleportato : MonoBehaviour {

	public GameObject target;

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Should be teleporting");
        GameObject teleportee = collider.gameObject;
        teleportee.transform.position = target.transform.position;
        teleportee.transform.rotation = target.transform.rotation;

        if(teleportee.tag == "Player")
        {
            teleportee.GetComponent<FirstPersonController>().SetRotation(target.transform);
        }
    }
}

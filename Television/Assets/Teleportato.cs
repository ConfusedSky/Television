using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Teleportato : MonoBehaviour {

    public float distanceToRender = 10;
    public GameObject target;
    private Camera destinationCamera = null;
    private GameObject player = null;
    private GameObject playerCamera = null;

    void Awake()
    {
        destinationCamera = target.GetComponentInChildren<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerCamera = player.GetComponentInChildren<Camera>().gameObject;
    }

    void Update()
    {
        Vector3 distance = playerCamera.transform.position - transform.position; 
        if(distance.magnitude < distanceToRender)
        {
            destinationCamera.transform.localPosition = distance;
            destinationCamera.gameObject.SetActive(true); 
            Quaternion rot = Quaternion.Inverse(transform.rotation) *
                playerCamera.transform.rotation;
            Quaternion end = rot * target.transform.rotation;
            destinationCamera.transform.rotation = end;
        }
        else
        {
            destinationCamera.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Should be teleporting");
        GameObject teleportee = collider.gameObject;
        teleportee.transform.position = target.transform.position;
        //teleportee.transform.rotation = target.transform.rotation;

        if(teleportee.tag == "Player")
        {
            Quaternion rot = Quaternion.Inverse(transform.rotation) *
                player.transform.rotation;
            Quaternion end = rot * target.transform.rotation;
            GameObject g = new GameObject();
            g.transform.rotation = end;
            teleportee.GetComponent<FirstPersonController>().SetRotation(g.transform);
            Destroy(g);
        }
    }
}

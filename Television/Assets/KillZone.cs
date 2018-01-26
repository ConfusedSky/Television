using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class KillZone : MonoBehaviour
{
    public Failure failure;
    public AudioClip siren;
    private BoxCollider c;

    void Start()
    {
        c = gameObject.GetComponent<BoxCollider>();
    }

    void OnDrawGizmos()
    {
        c = gameObject.GetComponent<BoxCollider>();
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = new Color(1,0,0,.2f);
        Gizmos.DrawCube(new Vector3(), c.size);
    }

    void OnTriggerEnter()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.clip = siren;
        source.Play();
        failure.Fail();
    }
}

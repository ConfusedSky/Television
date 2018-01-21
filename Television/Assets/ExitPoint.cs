using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour {
    public Mesh mesh;
    public float xRot;
    public float yRot;
    public float zRot;
    public float scale;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireMesh(mesh, transform.position, transform.rotation * Quaternion.Euler(xRot,yRot,zRot), transform.localScale * scale);
    }
}

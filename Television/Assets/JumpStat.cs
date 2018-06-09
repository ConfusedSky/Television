using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(BoxCollider))]
public class JumpStat : MonoBehaviour {

    private BoxCollider jumpOffPoint;
    private FirstPersonController player;

    private void OnDrawGizmosSelected()
    {
        jumpOffPoint = GetComponent<BoxCollider>();
        player = FindObjectOfType<FirstPersonController>();

        float offset = Mathf.Abs(player.m_RunSpeed * ( (2 * player.m_JumpSpeed) / 
                                                      (Physics.gravity.y * player.m_GravityMultiplier)));

        Vector3 size = jumpOffPoint.size;
        Vector3 worldSize = new Vector3(size.x * transform.lossyScale.x + 2 * offset,
                                        size.y * transform.lossyScale.y,
                                        size.z * transform.lossyScale.z + 2 * offset);
        Gizmos.color = Color.red;
        Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, new Vector3(1,1,1));
        Gizmos.matrix = rotationMatrix;

        Gizmos.DrawWireCube(new Vector3(), worldSize);
    }
}

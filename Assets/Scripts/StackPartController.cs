using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackPartController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private MeshRenderer meshRenderer;
    private StackController stackController;
    private Collider collider;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();  
        meshRenderer = GetComponent<MeshRenderer>();
        stackController = transform.parent.GetComponent<StackController>();
        collider = GetComponent<Collider>();
    }
    public void Shatter()
    {
        rigidBody.isKinematic = false;
        collider.enabled = false;

        Vector3 forcePoint = transform.parent.position;
        float parentXPos = transform.parent.position.x;
        float xPos = transform.position.x;

        Vector3 subDir = (parentXPos - xPos < 0) ? Vector3.right : Vector3.left;
        Vector3 dir = (Vector3.up * 1.5f + subDir).normalized;

        float force = Random.Range(20, 35);
        float torque = Random.Range(110, 180);

        rigidBody.AddForceAtPosition(dir * force, forcePoint, ForceMode.Impulse);
        rigidBody.AddTorque(Vector3.left * torque);
        rigidBody.velocity = Vector3.down;
    }

    public void RemoveAllChild()
    {
        for(int i = 0;i<transform.childCount;i++)
        {
            transform.GetChild(i).SetParent(null);
            i--;
        }
    }
}

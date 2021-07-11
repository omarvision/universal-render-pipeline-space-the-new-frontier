using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rock : MonoBehaviour
{
    public float Power = 3;
    public float Radius = 10;
    private Rigidbody rb = null;    

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
        Bounds bd = this.GetComponent<Renderer>().bounds;
        rb.mass = bd.size.x * bd.size.y * bd.size.z;

        float dir = Random.Range(0, 100);
        Vector3 rndDir = new Vector3(Random.Range(-dir, dir), Random.Range(-dir, dir), Random.Range(-dir, dir));
        rb.AddForce(rndDir, ForceMode.VelocityChange);

        float torq = 0.5f;
        Vector3 rndTorque = new Vector3(Random.Range(-torq, torq), Random.Range(-torq, torq), Random.Range(-torq, torq));
        rb.AddTorque(rndTorque, ForceMode.VelocityChange);
    }
}

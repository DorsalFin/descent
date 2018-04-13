using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnCollision : MonoBehaviour
{
    public GameObject explodePrefab;
    public float explodeForce;
    public float explodeRadius;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explodeRadius);
        foreach (Collider col in cols)
        {
            if (col.gameObject == gameObject) continue;

            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (rb)
                rb.AddExplosionForce(explodeForce, transform.position, explodeRadius);
        }

        Destroy(gameObject);
    }
}

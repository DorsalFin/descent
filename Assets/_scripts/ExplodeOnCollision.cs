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

            float force = explodeForce;

            Shield shield = col.GetComponent<Shield>();
            if (shield && shield.Active)
                force = shield.AbsorbForce(explodeForce, collision.contacts[0].point);

            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (rb)
                rb.AddExplosionForce(force, transform.position, explodeRadius);
        }

        Destroy(gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class ExplosionForce : MonoBehaviour {
    public float radius = 50.0F;
    public float power = 500.0F;

	void Update () {

        Explode();
	}

    void Explode()
    {
        Vector3 explosionPos = transform.position;
        if (Input.GetButtonDown("Fire3"))
        {
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                Destroy(gameObject);
                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 30.0F);
                }

            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 20;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, -speed));
        }
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        handleHit(coll.gameObject);
    }
    private void OnTriggerEnter(Collider coll)
    {
        handleHit(coll.gameObject);
    }
    private void handleHit(GameObject other)
    {
        if (other.tag == "enemy")
        {
            Destroy(other, 2f);
        }
    }
}
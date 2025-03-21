using UnityEngine;

public class BoatPhysics : MonoBehaviour
{
    public Transform water; // Referencja do wody
    public float buoyancyForce = 10f;

    void FixedUpdate()
    {
        Vector3 position = transform.position;
        float waterHeight = Mathf.Sin(Time.time + position.x); // Próbkowanie wysokości wody
        if (position.y < waterHeight)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * buoyancyForce);
        }
    }
}
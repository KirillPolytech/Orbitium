using UnityEngine;
public class Gravitation : MonoBehaviour
{
    public float GravitationConstant = 0.0000000008541557f;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            // To Sun.
            Vector3 Vector3Distance = transform.parent.position - other.transform.position;
            // Distance to sun.
            float DistanceToPlanet = Vector3Distance.magnitude;
            // Direction to sun.
            Vector3 DirectionToSun = Vector3Distance.normalized;

            float SunMass = transform.parent.GetComponent<Rigidbody>().mass;
            float OtherMass = other.gameObject.GetComponent<Rigidbody>().mass;
            // F = G * (m1*m2) / R^2 (Gravity).
            float Gravity = (SunMass * OtherMass) * GravitationConstant / (DistanceToPlanet * DistanceToPlanet);
            // Apply gravity.
            other.GetComponent<Rigidbody>().AddForce(Gravity * DirectionToSun, ForceMode.Impulse);
        }
    }
}

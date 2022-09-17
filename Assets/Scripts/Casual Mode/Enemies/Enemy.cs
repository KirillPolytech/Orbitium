using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Force = 5f;
    public float Range = 10f;
    public int ForceTime = 50;

    Rigidbody Rb;
    GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        Rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float Distance = (Player.transform.position - transform.position).magnitude;
        if (Distance < Range && ForceTime >= 0)
        {
            Vector3 Direction = Player.transform.position - transform.position;
            Rb.AddForce(Direction * Force, ForceMode.Acceleration);
            ForceTime--;
        }
    }
}

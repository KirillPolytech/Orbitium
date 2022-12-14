using UnityEngine;
using UnityEditor;

public class AddForceToObject : MonoBehaviour
{
    public int Strengh = 10;
    public Vector3 Direction;
    private int Timer = 0;
    void FixedUpdate()
    {
        if (Timer < 3)
        {
            GetComponent<Rigidbody>().AddForce(Direction * Strengh, ForceMode.Acceleration);
            Timer++;
        }
        Debug.DrawRay(transform.position, Direction, Color.red);
    } 
}

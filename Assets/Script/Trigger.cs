using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Trap;
    public GameObject Trap2;
    public GameObject Trap3;
    public Vector3 forceDirection = new Vector3(0, 0, 10); // Adjust as needed
    public float forceMagnitude = 15f; // Adjust as needed

    private void OnTriggerEnter(Collider other)
    {
        ApplyForce(Trap);
        ApplyForce(Trap2);
        ApplyForce(Trap3);
    }

    private void ApplyForce(GameObject trap)
    {
        if (trap != null)
        {
            Rigidbody rb = trap.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
            }
            else
            {
                Debug.LogWarning("No Rigidbody found on " + trap.name);
            }
        }
    }
}

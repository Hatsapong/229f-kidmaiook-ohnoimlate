using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Trap;
    public GameObject Trap2;
    public GameObject Trap3;
    public Vector3 forceDirection = new Vector3(0, 0, 10); // Adjust force direction and magnitude
    public float forceMagnitude = 10f; // Adjust as needed

    private void OnTriggerEnter(Collider other)
    {
        ApplyConstantForce(Trap);
        ApplyConstantForce(Trap2);
        ApplyConstantForce(Trap3);
    }

    private void ApplyConstantForce(GameObject trap)
    {
        if (trap != null)
        {
            Rigidbody rb = trap.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Force);
            }
            else
            {
                Debug.LogWarning("No Rigidbody found on " + trap.name);
            }
        }
    }
}

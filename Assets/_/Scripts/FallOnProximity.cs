using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallOnProximity : MonoBehaviour
{
    [Tooltip("PlayerArmature")]
    public Transform player;

    [Tooltip("Distance threshold to trigger the fall")]
    public float targetDistance = 5f;

    private Rigidbody rb;
    private bool hasFallen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Ensure gravity is off at the start
        rb.useGravity = false;
    }

    void Update()
    {
        // Stop checking once it has already been triggered
        if (hasFallen) return;

        if (player != null)
        {
            // Calculate distance between this object and the player
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= targetDistance)
            {
                TriggerFall();
            }
        }
    }

    void TriggerFall()
    {
        hasFallen = true;
        rb.useGravity = true; // Turns on Unity physics gravity

        // If you used "Is Kinematic" instead of turning off gravity, use:
        // rb.isKinematic = false; 
    }
}

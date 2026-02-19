using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Auto Run")]
    [SerializeField] private float baseSpeed = 3.0f;     // normal speed
    [SerializeField] private float maxSpeed = 8.0f;      // clamp upper
    [SerializeField] private float minSpeed = 0.5f;      // clamp lower

    [Header("State")]
    public bool isRunning = true;

    private Rigidbody2D rb;
    private float currentSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;

        currentSpeed = baseSpeed;
    }

    void FixedUpdate()
    {
        if (!isRunning) return;

        // Move right at constant speed (physics-friendly)
        Vector2 newPos = rb.position + Vector2.right * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }

    // ---------- Public controls (GameManager/toolbox can call these) ----------

    public void PauseRun()
    {
        isRunning = false;
    }

    public void ResumeRun()
    {
        isRunning = true;
    }

    public void ResetSpeed()
    {
        currentSpeed = baseSpeed;
    }

    public void SetSpeed(float newSpeed)
    {
        currentSpeed = Mathf.Clamp(newSpeed, minSpeed, maxSpeed);
    }

    public void ModifySpeed(float delta)
    {
        SetSpeed(currentSpeed + delta);
    }

    public float GetSpeed()
    {
        return currentSpeed;
    }
}

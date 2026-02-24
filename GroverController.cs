using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GroverController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private bool isRunning = true;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void FixedUpdate()
    {
        if (!isRunning) return;

        Vector2 nextPos = rb.position + Vector2.right * speed * Time.fixedDeltaTime;
        rb.MovePosition(nextPos);
    }

    // ---- controls you’ll use later (toolbox/tools/levels) ----
    public void Pause() => isRunning = false;
    public void Resume() => isRunning = true;

    public void SetSpeed(float newSpeed) => speed = Mathf.Max(0f, newSpeed);
    public void AddSpeed(float delta) => SetSpeed(speed + delta);

    public float GetSpeed() => speed;
}
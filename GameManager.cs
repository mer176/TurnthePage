using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GroverController grover;

    [Header("Timer")]
    [SerializeField] private float levelTime = 10f;

    private float timeRemaining;
    private bool active = true;

    void Start()
    {
        timeRemaining = levelTime;
    }

    void Update()
    {
        if (!active) return;

        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f)
        {
            Fail("Time ran out");
        }
    }

    public void Fail(string reason)
    {
        if (!active) return;
        active = false;

        Debug.Log("FAILED: " + reason);
        if (grover != null) grover.Pause();

        Invoke(nameof(ReloadScene), 1.0f);
    }

    public void Win()
    {
        if (!active) return;
        active = false;

        Debug.Log("WIN!");
        if (grover != null) grover.Pause();

        Invoke(nameof(ReloadScene), 1.0f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public float GetTimeRemaining()
    {
        return Mathf.Max(0f, timeRemaining);
    }
}
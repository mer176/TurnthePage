using UnityEngine;

public class EndOfPageTrigger : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.Fail("Grover reached the end of the page");
        }
    }
}
using UnityEngine;

public class EndGoalScript : MonoBehaviour
{
    public GameController gameController; // Make sure to assign this in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensuring only the player can trigger the win condition
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        if (gameController != null) // Check if gameController is not null
        {
            gameController.ShowVictoryPanel();
        }
        else
        {
            Debug.LogError("GameController is not assigned in the Inspector of EndGoalScript.");
        }
    }
}

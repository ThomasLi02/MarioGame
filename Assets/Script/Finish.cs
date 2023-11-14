using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject victoryPanel; // Drag your victory panel in the inspector to this reference
    public TMP_Text victoryScoreText;
    public bool stopGame = false;



    private void Update()  // Using LateUpdate instead of Update
    {
        if (stopGame && Input.GetKeyDown(KeyCode.Y))
        {
            RestartGame();
        }
    }


    public void ShowVictoryPanel()
    {
        victoryPanel.SetActive(true);
        this.gameObject.SetActive(true);
    

        // Stop the game by setting time scale to 0
        Time.timeScale = 0;

        // Update the score text on the victory screen
        if (victoryScoreText != null && ScoreKeeper.Singleton != null)
        {
            victoryScoreText.text = "Congratulations! \n"+"Score: " + ScoreKeeper.Singleton.Score.ToString();
            victoryScoreText.text += "\nPress Y to restart";
            stopGame = true;
        }
        else
        {
            Debug.LogError("Victory Score Text or ScoreKeeper Singleton not assigned/set properly!");
        }
    }
    public void ShowFailPanel()
    {
        victoryPanel.SetActive(true);
        this.gameObject.SetActive(true);

        // Stop the game by setting time scale to 0
        Time.timeScale = 0;

        // Update the score text on the victory screen
        if (victoryScoreText != null && ScoreKeeper.Singleton != null)
        {
            victoryScoreText.text = "You have died to the enemy\n" + "Score: 0";
            victoryScoreText.text += "\nPress Y to restart";
            stopGame = true;
        }
        else
        {
            Debug.LogError("Victory Score Text or ScoreKeeper Singleton not assigned/set properly!");
        }
    }




    // If you added a restart button
    public void RestartGame()
    {
        // Reset the time scale ybefore reloading the scene
        Time.timeScale = 1;
        stopGame = false;


        // This just reloads the current scene. You might have other logic.
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}



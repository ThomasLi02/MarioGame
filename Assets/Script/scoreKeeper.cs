using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Singleton;

    public AudioClip scoreSound; // Reference to the sound effect

    private AudioSource audioSource; // Reference to the AudioSource component

    public int Score;

    private TMP_Text scoreDisplay;

    void Start()
    {
        Singleton = this;
        scoreDisplay = GetComponent<TMP_Text>();
        audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource component to the game object
        Score = 0;
        scoreDisplay.text = "Score: " + Score.ToString();
    }

    public static void ScorePoints(int points)
    {
        Singleton.ScorePointsInternal(points);
    }

    private void ScorePointsInternal(int delta)
    {
        Score += delta;
        scoreDisplay.text = "Score: " + Score.ToString();

        // Play the sound effect
        if (scoreSound != null)
        {
            audioSource.PlayOneShot(scoreSound);
        }
    }
}

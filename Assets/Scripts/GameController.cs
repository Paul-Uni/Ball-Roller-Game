using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    [SerializeField] Material pom;
    [SerializeField] Material frog;

    public int hasToCollect;
    public int currentlyCollected;
    public float CurrentTime;
    public bool MessureTime;

    private const string HighScoreKeyLevel1 = "HighScore1";
    private const string HighScoreKeyLevel2 = "HighScore2";

    [SerializeField] GameObject PlayerPrefab;

    private void Start()
    {
        MessureTime = true;
        if (PlayerPrefs.GetInt("PlayerMaterial", 0) == 0)
        {
            Debug.Log("Pom Pom skin");
            PlayerPrefab.GetComponent<MeshRenderer>().material = pom;
        }
        if (PlayerPrefs.GetInt("PlayerMaterial", 0) == 1)
        {
            Debug.Log("Frog skin");
            PlayerPrefab.GetComponent<MeshRenderer>().material = frog;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MessureTime) CurrentTime = Time.timeSinceLevelLoad;
        
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void SaveHighScore(float score)
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            // Get the current high score from PlayerPrefs
            float currentHighScore = PlayerPrefs.GetFloat(HighScoreKeyLevel1, 0);

            // If the new score is higher than the current high score
            if (score < currentHighScore)
            {
                // Set the new high score
                PlayerPrefs.SetFloat(HighScoreKeyLevel1, score);

                // Save the changes to PlayerPrefs
                PlayerPrefs.Save();
            }
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            // Get the current high score from PlayerPrefs
            float currentHighScore = PlayerPrefs.GetFloat(HighScoreKeyLevel2, 0);

            // If the new score is higher than the current high score
            if (score < currentHighScore)
            {
                // Set the new high score
                PlayerPrefs.SetFloat(HighScoreKeyLevel2, score);

                // Save the changes to PlayerPrefs
                PlayerPrefs.Save();
            }
        }
    }

    public float GetHighScore()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            return PlayerPrefs.GetFloat(HighScoreKeyLevel1, 0f);
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            return PlayerPrefs.GetFloat(HighScoreKeyLevel2, 0f);
        }
        else return 0f;
    }
}

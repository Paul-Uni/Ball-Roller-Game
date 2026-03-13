using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] AudioSource aS;
    [SerializeField] AudioClip aC;
    AudioSource PlayerSource;
    float clipLength;
    bool hasCollided;
    Camera cam;
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        clipLength = aC.length;
        PlayerSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        cam = Camera.main;
        gameController = cam.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !hasCollided && gameController.hasToCollect == gameController.currentlyCollected) 
        {
            hasCollided = true;
            StartCoroutine(FinishTheGame());
        }
    }

    IEnumerator FinishTheGame()
    {
        PlayerSource.Stop();
        aS.PlayOneShot(aC);
        gameController.MessureTime = false;
        yield return new WaitForSeconds(clipLength);
        gameController.SaveHighScore(gameController.CurrentTime);
        SceneManager.LoadScene("MainMenu");
    }
}

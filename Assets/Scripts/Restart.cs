using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    Camera cam;
    GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        controller = cam.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            controller.CurrentTime = 0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }
}

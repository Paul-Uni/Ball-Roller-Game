using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    Camera cam;
    GameController gameController;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        gameController = cam.GetComponent<GameController>();
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"{gameController.CurrentTime:F2}\n" +
            $"{gameController.GetHighScore():F2}";
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextCollect : MonoBehaviour
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
        text.text = $"{gameController.currentlyCollected} / {gameController.hasToCollect}";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Camera cam;
    [SerializeField] AudioClip aC;
    [SerializeField] AudioSource aS;
    private GameController gameController;
    public float rotationSpeed = 45f;
    Rigidbody rb;
    MeshRenderer mRenderer;
    BoxCollider bCollider;

    // Start is called before the first frame update11
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        gameController = cam.GetComponent<GameController>();
        mRenderer = GetComponent<MeshRenderer>();
        bCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate rotation amount for this frame
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Create a Quaternion for rotation around the x and y axes
        Quaternion rotation = Quaternion.Euler(rotationAmount, rotationAmount, 0);

        // Apply the rotation to the object
        transform.rotation *= rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameController.currentlyCollected += 1;
            aS.PlayOneShot(aC);
            mRenderer.enabled = false;
            bCollider.enabled = false;
            Destroy(gameObject,aC.length);
        }
    }
}

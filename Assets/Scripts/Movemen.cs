using UnityEngine;

public class Movemen : MonoBehaviour
{
    //Normal Mode
    bool isPlayer;

    //Movement Variables
    [SerializeField] float speed = 40f;
    //Jumping
    [SerializeField] float jumpForce = 25f;
    private bool jumpRequest;
    private bool grounded;
    private bool canAirJump;


    //God Mode
    bool isGod;

    //Movement Variables
    [SerializeField] float oscillation = 0.05f;
    [SerializeField] float flightSpeed = 0.1f;
    //Rotation
    private Quaternion baseRotation;


    //Declerations
    private Camera cam;
    private Vector3 camPos;

    //Physics stuff
    private Rigidbody rb;

    //General
    [SerializeField] public ParticleSystem particleSys;

    void Start()
    {
        cam = Camera.main;
        
        rb = GetComponent<Rigidbody>();

        isPlayer = true;
        isGod = false;

        baseRotation = rb.rotation;
    }

    private void Update()
    {
        ToggleMode();

        //Camera
        camPos = new Vector3(transform.position.x,0,transform.position.z-5);
        cam.transform.position = camPos;

        if (isGod )
        {
            GodMovement();
        }

        //Normal Movement
        if (isPlayer)
        {
            Jumping();
        }
    }

    void FixedUpdate()
    {
        if (isPlayer)
        {
            //Movement
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * Time.fixedDeltaTime * speed);

            //Jumping
            if (jumpRequest)
            {
                jumpRequest = false;
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && rb.velocity.magnitude > .5f)
        {
            PlayParticles(collision.contacts[0].point);
        }
    }


    void Jumping()
    {
        //jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                jumpRequest = true;
            }
            else if (canAirJump)
            {
                jumpRequest = true;
                canAirJump = false;
            }
        }
    }

    private void GodMovement()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            MoveInDirection(new Vector3(0, -1, 0), oscillation);
        }

        if (Input.GetKey(KeyCode.E))
        {
            MoveInDirection(new Vector3(0, 1, 0), oscillation);
        }

        if (Input.GetKey(KeyCode.W))
        {
            MoveInDirection(new Vector3(0, 0, 1), flightSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveInDirection(new Vector3(-1, 0, 0), flightSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveInDirection(new Vector3(0, 0, -1), flightSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveInDirection(new Vector3(1, 0, 0), flightSpeed);
        }
    }

    void MoveInDirection(Vector3 direction, float speed)
    {
        transform.position += direction * speed;
    }

    void ToggleMode()
    {
        if (Input.GetKeyDown(KeyCode.G)) 
        {
            isGod = !isGod;
            isPlayer = !isPlayer;

            rb.isKinematic = !rb.isKinematic;

            if (isGod)
            {
                rb.rotation = baseRotation;
            }
        }
    }

    private void PlayParticles(Vector3 collisionPos)
    {
        ParticleSystem psInstance = Instantiate(particleSys,collisionPos , Quaternion.identity);
        psInstance.Play();

        Destroy(psInstance.gameObject, psInstance.main.duration);
    }

    public void SetGrounded(bool grounded)
    {
        this.grounded = grounded;
    }

    public void SetAirJump(bool airJump)
    {
        this.canAirJump = airJump;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //So you can use SceneManager

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    //Speed Variables---------------------
    public float speed = 3f;
    public float normalSpeed = 3f;
    public float sprintSpeed = 6f;
    public int stamina = 100;
    public int sweatDuration = 150;
    public bool isRunning;
    //-------------------------------------

    //Animation Variables---------------------
    private Animator anim;
    //----------------------------------------


    //Jumping Variables---------------------
    public bool isGrounded = true;
    public int jumpDelay= 0;
    //--------------------------------------

    //Damage Variables----------------------
    public int hurtTimer = 0;
    public bool isDead;
    public static bool ButtonsEnabled = true;
//--------------------------------------


// Checks if the player collides with any object
private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit Detected"); // Prints out hit detected

        if (other.gameObject.tag == "Traps") // Checks if the player is colliding with any of the traps
        {
            Destroy(other.gameObject);
            anim.SetBool("trapHit", true); 
            Debug.Log("Trap Hit");
            hurtTimer = 75;
            speed = 0;
            anim.SetBool("isHurt", true); // Sets the condition for hurt animation to true
            HealthScript.health -= 1; // Removes one heart if the player hits a trap
        }

        if (other.gameObject.tag == "InstaDeath") // Checks if the player is colliding with any of the traps
        {
            anim.SetBool("trapHit", true);
            Debug.Log("You ded");
            isDead = true;
            ButtonsEnabled = false;
            anim.SetBool("isDead", true); // Sets the condition for hurt animation to true
            HealthScript.health = 0; // Removes one heart if the player hits a trap
            if (other.gameObject.name == "Pot")
            {
                DeathScreen.DeathText.text = "You Turned Into Mouse Stew";
            }
        }



        if (other.gameObject.tag == "Objectives") // Checks if the player is colliding with any of the objectives
        {
            Destroy(other.gameObject);
            Debug.Log("Cheese Hit");
            ScoreTextScript.cheeseAmount += 1; // Adds to the amount of cheese the player has collected
        }

        if (other.gameObject.tag == "RestartBoundaries") // Checks if the player is colliding with any of the outside boundaries
        {
            // Resets all stats
            HealthScript.health = 3;
            ScoreTextScript.cheeseAmount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.gameObject.tag == "Ground") // Checks if the player is touching the ground
        {
            isGrounded = true; // Sets boolean to true allowing player to jump
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // Calls the animator component
        rb = GetComponent<Rigidbody>(); // Calls the rigidbody component
    }

    // Update is called once per frame
    void Update()
    {
        // Sets the keys WASD as inputs to move the player
        if (ButtonsEnabled == true)
        {
            float Horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");
            if (Horizontal == 0 && Vertical == 0) // Checks if the player is not moving
            {
                anim.SetBool("isWalking", false); // Activates the idle animation
            }


            else
            {
                anim.SetBool("isWalking", true); // Activates the walk animation
            }
            // Updates the players position
            Vector3 move = new Vector3(Horizontal, 0, Vertical) * speed * Time.deltaTime;
            transform.Translate(move);
        }
    


        if (Input.GetKey(KeyCode.LeftShift) && ButtonsEnabled == true) // Sprint function for the player
        {
            stamina -= 2;
            isRunning = true;
            anim.SetBool("isRunning", true); // Activates running animation
            anim.SetBool("isTired", true);
            anim.SetBool("isWalking", true);
        }

        if (isRunning == true)
        {
            speed = sprintSpeed; // Changes player speed
        }

        if (isGrounded == true && jumpDelay <= 0) // Jump function for the player
        {
            if (Input.GetKey(KeyCode.Space) && ButtonsEnabled == true) // Checks if the player presses the spacebar, allowing them to jump
            {
                jumpDelay = 75; // Turns on the jump delay to prevent bunny hopping
                isGrounded = false;
                anim.SetBool("isJumping", true); // Turns on the jump animation
                rb.AddForce(0f, 2000f, 0f); // Adds an upward force to the player
            }


        }

        if (isGrounded == true) // Checks to see if the player is touching the ground
        {
            jumpDelay -= 1; // Counts down the jump delay
            anim.SetBool("isJumping", false); // Turns off the jump animation
        }



        if (Input.GetKeyUp(KeyCode.LeftShift) || stamina <= 0) // Checks if the player is trying to sprint while being out of stamina
        {
            isRunning = false;
            speed = normalSpeed; // Returns the players speed back to the default speed
            anim.SetBool("isRunning", false); // Turns off the running animation
            anim.SetBool("isTired", true);
            sweatDuration = 50;
            if (sweatDuration == 50)
            {
                sweatDuration -= 50;
            }

            else
            {
                anim.SetBool("isTired", false);
            }




        }

        if(speed == 0)
        {
            isRunning = false;
        }

        if (stamina < 100) // Increases stamina when it is less than the maximum
        {
            stamina += 1;
        }

        if (stamina <= 0) // Prevents negative stamina
        {
            stamina = 0;
        }


        if (hurtTimer > 0) // Counts down the hurt timer when it is greater than 0. When the player is hurt
        {
            hurtTimer -= 1;
            
        }

        if (hurtTimer <= 0) // Checks if the player is not colliding with any of the traps
        {
            anim.SetBool("isHurt", false);
            if (speed == 0 && isRunning == false && isDead == false)
            {
                speed = normalSpeed;
            }
            else if (isRunning == true)
            {
                speed = sprintSpeed;
            }
           
        }   



       
        // Actually moves the player
        Debug.Log(speed.ToString());
        Debug.Log("stamina: " + stamina);
        Debug.Log("Fatigue duration: " + sweatDuration);

    }




}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicRotation : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Sets the keys WASD as inputs to move the player
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        // Updates the players position

        // Rotates the player to face the direction of movement
        if (Input.GetKey(KeyCode.D) && PlayerController.ButtonsEnabled == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.right),0.02f);
        }

        else if (Input.GetKey(KeyCode.A) && PlayerController.ButtonsEnabled == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.right *-1f),0.02f);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //So you can use SceneManager
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public static int health = 3;
    public Animator anim;
    public static int deathTimer = 75;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 2)
        {
            if (gameObject.name == "Heart3")
            {
                Destroy(gameObject);
                
            }
        }

        else if (health == 1)
        {
            if (gameObject.name == "Heart2")
            {
                Destroy(gameObject);
            }
        }

        else if (health == 0)
        {
            deathTimer -= 1;
            if (gameObject.tag == "Health")
            {
                Destroy(gameObject);
                
                    if (deathTimer <= 0)
                {
                    health = 3;
                    anim.SetBool("isDead", false);
                    ScoreTextScript.cheeseAmount = 0;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                }
            }
            if(gameObject.tag == "CheeseCollected")
            {
                Destroy(gameObject);
            }
        }

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (other.gameObject.tag == "Player")
        {
            HealthScript.health = 3;
            ScoreTextScript.cheeseAmount = 0;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}

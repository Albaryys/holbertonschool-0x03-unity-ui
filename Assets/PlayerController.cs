using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerBody;
    public float speed = 1000;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;

    // triggered for interactables
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
            SetScoreText();
        }

        if (other.tag == "Trap")
        {
            health--;
            Debug.Log("Health: " + health);
            SetHealthText();
        }

        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
            winLoseBG.gameObject.SetActive(true);
            winLoseText.color = Color.black;
            winLoseBG.color = Color.green;
            winLoseText.text = "You win!";
        }

        if (other.tag == "Teleporter")
        {
            Vector3 currentPos = transform.position;

            if (currentPos == new Vector3(20.63f, 0.26f, -9.23f))
            {
                transform.position = new Vector3(-22.23f, 0.26f, -21.89f);
            }
            else
            {
                transform.position = new Vector3(-22.23f, 0.26f, -21.89f);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update the movement of the player
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        playerBody.AddForce(movement * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
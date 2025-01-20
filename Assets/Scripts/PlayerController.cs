using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Speed of the player mouvement
    public float speed;
    // Score text displayed on the ScoreText GameObject
    public TextMeshProUGUI scoreText;

    // health of the player
    public int health;

    private Rigidbody rb;
    private float vertical;
    private float horizontal;
    private int score;

    private bool isTeleporting;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0; 
        isTeleporting = false;
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        // DEPLACEMENT
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 mouvement = new Vector3(horizontal, 0, vertical).normalized;
        rb.velocity = new Vector3(mouvement.x* speed, rb.velocity.y, mouvement.z * speed);

        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            score += 1;
            //Debug.Log("Score: " + score);
            this.SetScoreText();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            Debug.Log("Health: " + health);
        }
        else if(other.gameObject.tag == "Goal")
        {
            Debug.Log("You win!");
        }
        else if (other.gameObject.tag == "Teleporter")
        {
            if (isTeleporting)
            {
                isTeleporting = false;
            }
            else
            {
                isTeleporting = true;
                other.gameObject.SetActive(false);
                GameObject teleporterCible  = GameObject.FindWithTag("Teleporter");
                transform.position = teleporterCible.transform.position;
                other.gameObject.SetActive(true);
            }
            
        }
    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}

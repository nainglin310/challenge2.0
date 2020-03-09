using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text scoreText;

    public Text winText;

    private int scoreValue = 0;

    public Text livesText;

    private int livesValue = 3;

    public Text loseText;




    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        SetScoreText();
        SetLivesText();
        winText.text = "";
        loseText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1; 
            Destroy(collision.collider.gameObject);
            SetScoreText();
        }

        if (collision.collider.tag == "Enemy")
        {
            livesValue -= 1;
            Destroy(collision.collider.gameObject);
            SetLivesText();
        }

    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + scoreValue.ToString();
        if (scoreValue >= 4)
        {
            winText.text = "You Win! Game created by Naing Lin.";
        }
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + livesValue.ToString();
        if (livesValue <= 0)
        {
            loseText.text = "You Lose! Game created by Naing Lin.";
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }
}
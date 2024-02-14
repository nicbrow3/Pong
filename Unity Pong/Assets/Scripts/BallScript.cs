using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 10;
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] public TextMeshProUGUI playerScore;
    [SerializeField] public TextMeshProUGUI AIScore;

    private int hitCounter;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2f); //Waits 2 seconds, then calls the StartBall function
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease*hitCounter));
    }
 
    private void StartBall()
    {
        rb.velocity = new Vector2(-1, 0)*(initialSpeed + speedIncrease*hitCounter);
    }

    private void ResetBall() //Actions to take after a score
    {
        rb.velocity = new Vector2(0,0); //0 out velocity
        transform.position = new Vector2(0,0); //reset position
        hitCounter = 0; //reset hitcounter
        Invoke("StartBall", 2f); //Waits 2 seconds, then calls the StartBall function
    }

    private void PlayerBounce(Transform myObject)
    {
        hitCounter ++;

        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;

        float xDirection, yDirection;
        if (transform.position.x > 0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }

        yDirection = (ballPos.y - playerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;
        if (yDirection == 0)
        {
            yDirection = 0.25f;
        }
        rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + (speedIncrease * hitCounter));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "AI")
        {
            PlayerBounce(collision.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(transform.position.x >0)
        {
            ResetBall();
            playerScore.text = (int.Parse(playerScore.text) + 1).ToString();
        }
        else if(transform.position.x < 0)
        {
            ResetBall();
            AIScore.text = (int.Parse(AIScore.text) + 1).ToString();
        }
    }
}

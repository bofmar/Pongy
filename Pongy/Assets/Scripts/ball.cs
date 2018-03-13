using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

    public float speed = 30;

    private Rigidbody2D rigidBody;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;

		
	}

    void OnCollisionEnter2D(Collision2D col)
    {

        //check if we collided with paddle_left or paddle_right

        if((col.gameObject.name == "paddle_left") || (col.gameObject.name == "paddle_right"))
        {

            HandlePaddleHit(col);

        }

        //check if we collided with wall_bot or wall_top

        if ((col.gameObject.name == "wall_top") || (col.gameObject.name == "wall_bot"))
        {

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallBloop);

        }

        //check if we collided with goal_right or goal_left

        if ((col.gameObject.name == "goal_right") || (col.gameObject.name == "goal_left"))
        {

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.goalBloop);

            //TODO update score UI

            transform.position = new Vector2(0, 0);
        }

    }

    void HandlePaddleHit(Collision2D col)
    {
        float y = BallHitPaddleWhere(transform.position,col.transform.position,
            col.collider.bounds.size.y);

        Vector2 dir = new Vector2();

        if(col.gameObject.name == "paddle_left")
        {
            dir = new Vector2(1, y).normalized;
        }

        if(col.gameObject.name == "paddle_right")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = dir * speed;

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitPaddleBloop);
    }

    float BallHitPaddleWhere(Vector2 ball,Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }
}

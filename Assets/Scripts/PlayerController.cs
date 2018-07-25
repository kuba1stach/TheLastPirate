using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject CannonBall;
    public float speed = 15f;
    public float padding = 1f;

    public float ballSpeed;
    public float firingRate;

    float xmin;
    float xmax;

	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;

    }

    void Fire()
    {
        GameObject ball = Instantiate(CannonBall, new Vector3(transform.position.x, transform.position.y + 0.6f), Quaternion.identity) as GameObject;
        Rigidbody2D ball_rb = ball.AddComponent<Rigidbody2D>() as Rigidbody2D;

        ball_rb.gravityScale = 0;
        ball_rb.velocity = new Vector3(0, ballSpeed, 0);

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }


        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.0001f, firingRate);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
    }
}

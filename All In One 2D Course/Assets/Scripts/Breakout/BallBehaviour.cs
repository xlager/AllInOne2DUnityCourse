using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    bool started = false;
    [SerializeField] Transform paddle;
    float paddleX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            started = true;
            rb.velocity = new Vector2(2, 2);

        }
        if (started)
        {
            //rb.freezeRotation = false;
        }
        else
        {
            rb.freezeRotation = true;
            transform.position = new Vector2(paddle.position.x, transform.position.y);
        }
    }

    private void OnClollisionEnter2D(Collision2D collision)
    {

    }
}

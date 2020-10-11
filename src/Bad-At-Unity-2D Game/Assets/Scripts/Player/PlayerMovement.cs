using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool facingRight = true;
    float speed = 3.0f;
    private float horizontal;
    private float vertical;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }

        else if (horizontal < 0 && facingRight)
        {
            Flip();
        }

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}

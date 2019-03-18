using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private Rigidbody2D rigid;

    public float speed = 1;
    public float high = 2;
    private bool IsJumping;
    public LayerMask layerMask;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.rigid.velocity = new Vector2(speed * -1, rigid.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.rigid.velocity = new Vector2(speed, rigid.velocity.y);
        }
        else
        {
            this.rigid.velocity = new Vector2(0.0f, rigid.velocity.y);
        }
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Physics2D.Raycast(transform.position, -transform.up, 1, layerMask))
            {
                if (!IsJumping)
                {
                    IsJumping = true;
                    rigid.AddForce(Vector2.up * high, ForceMode2D.Impulse);
                }
                else
                {
                    return;
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D coll2)
    {
        IsJumping = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//[RequireComponent(typeof(Rigidbody))]
public class EnemyScript : MonoBehaviour
{

    public int power;
    public Animator animator;

    ////public class PlayerController : MonoBehaviour
    ////{

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody2D rb;

    Vector3 checkPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay2D()
    {
        //isGrounded = true;
        Vector2 checkPoint = transform.position + Vector3.down;
        if (Physics2D.OverlapPoint(checkPoint))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void Update()
    {
        checkPos = transform.position + Vector3.down;
        Debug.DrawLine(transform.position, checkPos);

        if (isGrounded)
        {
            animator.SetTrigger("HitGround");
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            Invoke("DelayTrigger", 1.0f);
        }

        //if (isGrounded == false)
        //{
        //    animator.SetTrigger("NotOnGround");
        //}

    }

    void DelayTrigger()
    {
        animator.SetTrigger("NotOnGround");
    }




    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.tag.Equals("Ground"))
        {
            if (col.gameObject.transform.position.y < transform.position.y)
            {
                rb.AddForce(Vector2.up * power);
            }

        }
        if (col.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }
}

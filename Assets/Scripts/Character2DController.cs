using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public bool inputCheck;
    public bool movingRight = true;
    public float timeforInput = 0.25f;
    public float inputTime = 0.0f;
    public int timesPressed = 0;
    public int numberOfClicks = 0;
    public float MovementSpeed = 1;
    public int coinValue = 1;
    Vector3 checkPos;
    private float secondsHeld;
    public bool stopMoving;

    public LayerMask wallsMask;


    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //var movement = Input.GetAxis("Horizontal");
        //transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            secondsHeld = 0;
            stopMoving = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //nothing here
            secondsHeld += Time.deltaTime;
            if (secondsHeld > 0.25f)
            {
                stopMoving = true;
            }
        }
        else
        {
            if (!stopMoving)
            {
                DecideMoveDirection();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inputTime = 0;
            timesPressed++;
            inputCheck = true;
        }

        if (inputCheck)
        {
            inputTime += Time.deltaTime;
            if (inputTime > timeforInput)
            {
                if (timesPressed == 2)
                {
                    movingRight = !movingRight;
                    GetComponent<SpriteRenderer>().flipX = !movingRight;
                }
               
                inputCheck = false;
                timesPressed = 0;
               
            }
        }
    }

    void DecideMoveDirection()
    {
        if (movingRight)
        {
            //check right
            Vector2 checkPoint = transform.position + Vector3.right;
            if (Physics2D.OverlapPoint(checkPoint, wallsMask))
            {
                movingRight = !movingRight;
                GetComponent<SpriteRenderer>().flipX = !movingRight;
            }
            checkPos = transform.position + Vector3.right;
            Debug.DrawLine(transform.position, checkPos);
            transform.Translate(Vector2.right * Time.deltaTime * MovementSpeed);
        }
        else if (!movingRight)
        {
            Vector2 checkPoint = transform.position + Vector3.left;
            if (Physics2D.OverlapPoint(checkPoint, wallsMask))
            {
                movingRight = !movingRight;
                GetComponent<SpriteRenderer>().flipX = !movingRight;
            }
            checkPos = transform.position + Vector3.left;
            Debug.DrawLine(transform.position, checkPos);
            transform.Translate(Vector2.left * Time.deltaTime * MovementSpeed);
        }
    }


}

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
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //var movement = Input.GetAxis("Horizontal");
        //transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetKey(KeyCode.Space))
        {
            //nothing here
        }
        else
        {
            if (movingRight)
            { 
                transform.Translate(Vector2.right * Time.deltaTime * MovementSpeed); 
            }
            else if (!movingRight)
            {
                transform.Translate(Vector2.left * Time.deltaTime * MovementSpeed);
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
                    movingRight = !movingRight;

                GetComponent<SpriteRenderer>().flipX = false;
                numberOfClicks++;
               
                inputCheck = false;

                if (numberOfClicks % 1 == 0)
                {
                   movingRight = !movingRight;
                }

                if (numberOfClicks % 2 == 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                   
                }
            }
        }
    }

}

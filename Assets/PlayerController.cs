using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    //SpriteRenderer SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //SpriteRenderer = GetComponent<SpriteRenderer>();

    }


    void Update()
    {
        // Check for key presses for movement in specific directions
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //Move(Vector3.left);
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            //Move(Vector3.right);
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }

        else if(Input.GetKey(KeyCode.UpArrow))
        {
            //Move(Vector3.up);
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            //Move(Vector3.down);
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
    }

    void Move(Vector3 direction)
    {
        // Move the object based on the specified direction
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}


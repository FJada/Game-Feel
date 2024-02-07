using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;

    bool swing = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            swing = true;
            animator.SetBool("IsSwinging", true);

        }
        else
        {
            swing = false;
            animator.SetBool("IsSwinging", false); 
        }

    }

    public void OnSwinging(bool isSwinging)
    {
        animator.SetBool("IsSwinging", isSwinging);
    }

}
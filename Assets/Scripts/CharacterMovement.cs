using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    float speed = 1;

    // Update is called once per frame
    void Update()
    {
        //replace with buttons
        if (Input.GetKeyDown(KeyCode.W)){
            if (Raycast(0))
            {
                transform.position += transform.forward * speed;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.A)){
            if (Raycast(1))
            {
                transform.position += transform.right * -speed;
            }
        }
        if (Input.GetKeyDown(KeyCode.S)){
            if (Raycast(2))
            {
                transform.position += transform.forward * -speed;
            }
        }
        if (Input.GetKeyDown(KeyCode.D)){
            if (Raycast(3))
            {
                transform.position += transform.right * speed;
            }
        }
    }

    bool Raycast(float direction)
    {
        if(direction == 0)
        {
            Ray playerRay = new Ray(transform.position, transform.forward);
            RaycastHit playerHit;

            if (Physics.Raycast(playerRay, out playerHit, .5f))
            {
                if (playerHit.transform.CompareTag("Building")) {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        else if (direction == 1)
        {
            Ray playerRay = new Ray(transform.position, -transform.right);
            RaycastHit playerHit;

            if (Physics.Raycast(playerRay, out playerHit, .5f))
            {
                if (playerHit.transform.CompareTag("Building")) {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        else if (direction == 2)
        {
            Ray playerRay = new Ray(transform.position, -transform.forward);
            RaycastHit playerHit;

            if (Physics.Raycast(playerRay, out playerHit, .5f))
            {
                if (playerHit.transform.CompareTag("Building")) {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        else if (direction == 3)
        {
            Ray playerRay = new Ray(transform.position, transform.right);
            RaycastHit playerHit;

            if (Physics.Raycast(playerRay, out playerHit, .5f))
            {
                if (playerHit.transform.CompareTag("Building")){
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }


    }

    public Transform RaycastDown()
    {
        Ray playerRay = new Ray(transform.position, -transform.up);
        RaycastHit playerHit;

        if(Physics.Raycast(playerRay, out playerHit))
        {
            if(playerHit.transform.GetComponent<Walkable>() != null)
            {
                Transform Location = playerHit.transform;
                return Location;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}

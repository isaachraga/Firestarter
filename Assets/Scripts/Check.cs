using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
 

    
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Raycast(0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Raycast(1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Raycast(2);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Raycast(3);
        }
    }

    void Raycast(float direction)
    {
        if (direction == 0)
        {
            Ray playerRay = new Ray(transform.position, transform.forward);
            RaycastHit playerHit;

            if (Physics.Raycast(playerRay, out playerHit, .5f))
            {
                if (playerHit.transform.CompareTag("Building"))
                {
                    playerHit.collider.gameObject.GetComponent<Burn>().BurnBuilding();
                }
                
            }
           
        }
        else if (direction == 1)
        {
            Ray playerRay = new Ray(transform.position, -transform.right);
            RaycastHit playerHit;

            if (Physics.Raycast(playerRay, out playerHit, .5f))
            {
                if (playerHit.transform.CompareTag("Building"))
                {
                    playerHit.collider.gameObject.GetComponent<Burn>().BurnBuilding();
                }
            }
            
        }
        else if (direction == 2)
        {
            Ray playerRay = new Ray(transform.position, -transform.forward);
            RaycastHit playerHit;

            if (Physics.Raycast(playerRay, out playerHit, .5f))
            {
                if (playerHit.transform.CompareTag("Building"))
                {
                    playerHit.collider.gameObject.GetComponent<Burn>().BurnBuilding();
                }
            }
           
        }
        else if (direction == 3)
        {
            Ray playerRay = new Ray(transform.position, transform.right);
            RaycastHit playerHit;

            if (Physics.Raycast(playerRay, out playerHit, .5f))
            {
                if (playerHit.transform.CompareTag("Building"))
                {
                    playerHit.collider.gameObject.GetComponent<Burn>().BurnBuilding();
                }
            }
            
        }
    }

   
}

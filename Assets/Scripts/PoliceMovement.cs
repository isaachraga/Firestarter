using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class PoliceMovement : MonoBehaviour
{
    float speed = 1;
    public float CheckRate = 1f;
    float Timer;

    public bool pathfinding = false;

    [Space]

    public Transform currentCube;
    public Transform clickedCube;
   

    public List<Transform> finalPath = new List<Transform>();

    void Update()
    {
        Timer += Time.deltaTime;


        if (!pathfinding)
        {
            Debug.Log(Timer);
            if (Timer >= CheckRate)
            {

                if (Raycast(0) || Raycast(1) || Raycast(2) || Raycast(3))
                {
                    //Start Pathfinding
                    pathfinding = true;
                    FindPath();
                    Debug.Log("Start Path");
                }
                Timer = 0;
            }
        }
        


    }
    public void RaycastDown()
    {
        Ray playerRay = new Ray(transform.position, -transform.up);
        RaycastHit playerHit;

        if (Physics.Raycast(playerRay, out playerHit))
        {
            if (playerHit.transform.GetComponent<Walkable>() != null)
            {
                currentCube = playerHit.transform;
                
            }
           
        }
 
    }

   
    void FindPath()
    {
        List<Transform> nextCubes = new List<Transform>();
        List<Transform> pastCubes = new List<Transform>();

        foreach (WalkPath path in currentCube.GetComponent<Walkable>().possiblePaths)
        {
            if (path.active)
            {
                nextCubes.Add(path.target);
                path.target.GetComponent<Walkable>().previousBlock = currentCube;
            }
        }

        pastCubes.Add(currentCube);

        ExploreCube(nextCubes, pastCubes);
        BuildPath();
    }

    void ExploreCube(List<Transform> nextCubes, List<Transform> visitedCubes)
    {
        Transform current = nextCubes.First();
        nextCubes.Remove(current);

        if (current == clickedCube)
        {
            return;
        }

        foreach (WalkPath path in current.GetComponent<Walkable>().possiblePaths)
        {
            if (!visitedCubes.Contains(path.target) && path.active)
            {
                nextCubes.Add(path.target);
                path.target.GetComponent<Walkable>().previousBlock = current;
            }
        }

        visitedCubes.Add(current);

        if (nextCubes.Any())
        {
            ExploreCube(nextCubes, visitedCubes);
        }
    }

    void BuildPath()
    {
        Transform cube = clickedCube;
        while (cube != currentCube)
        {
            finalPath.Add(cube);
            if (cube.GetComponent<Walkable>().previousBlock != null)
                cube = cube.GetComponent<Walkable>().previousBlock;
            else
                return;
        }

        finalPath.Insert(0, clickedCube);

        FollowPath();
    }

    void FollowPath()
    {
        Sequence s = DOTween.Sequence();

        pathfinding = true;

        for (int i = finalPath.Count - 1; i > 0; i--)

            //
            //turn tweening into snapping on time
            //
        {
           // float time = finalPath[i].GetComponent<Walkable>().isStair ? 1.5f : 1;

            s.Append(transform.DOMove(finalPath[i].GetComponent<Walkable>().GetWalkPoint(), .2f).SetEase(Ease.Linear));

           // if (!finalPath[i].GetComponent<Walkable>().dontRotate)
               // s.Join(transform.DOLookAt(finalPath[i].position, .1f, AxisConstraint.Y, Vector3.up));
        }

       /* if (clickedCube.GetComponent<Walkable>().isButton)
        {
            s.AppendCallback(() => GameManager.instance.RotateRightPivot());
        }*/

        s.AppendCallback(() => Clear());
    }

    void Clear()
    {
        foreach (Transform t in finalPath)
        {
            t.GetComponent<Walkable>().previousBlock = null;
        }
        finalPath.Clear();
        pathfinding = false;

    }


    bool Raycast(float direction)
     {
         if (direction == 0)
         {
             Ray playerRay = new Ray(transform.position, transform.forward);
             RaycastHit playerHit;

             if (Physics.Raycast(playerRay, out playerHit))
             {
                 if (playerHit.transform.CompareTag("Player"))
                 {
                    clickedCube = playerHit.transform.GetComponent<CharacterMovement>().RaycastDown();
                    RaycastDown();
                     return true;
                 }
                 else
                 {
                     return false;
                 }
             }
             if (Physics.Raycast(playerRay, out playerHit, .5f))
             {
                 if (playerHit.transform.CompareTag("Building"))
                 {
                     return false;
                 }
                 else
                 {
                    return false;
                }
             }
             else
             {
                 return false;
             }
         }
         else if (direction == 1)
         {
             Ray playerRay = new Ray(transform.position, -transform.right);
             RaycastHit playerHit;

            if (Physics.Raycast(playerRay, out playerHit))
            {
                if (playerHit.transform.CompareTag("Player"))
                {
                    clickedCube = playerHit.transform.GetComponent<CharacterMovement>().RaycastDown();
                    RaycastDown();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (Physics.Raycast(playerRay, out playerHit, .5f))
            {
                if (playerHit.transform.CompareTag("Building"))
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
         else if (direction == 2)
         {
             Ray playerRay = new Ray(transform.position, -transform.forward);
             RaycastHit playerHit;

            if (Physics.Raycast(playerRay, out playerHit))
            {
                if (playerHit.transform.CompareTag("Player"))
                {
                    clickedCube = playerHit.transform.GetComponent<CharacterMovement>().RaycastDown();
                    RaycastDown();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (Physics.Raycast(playerRay, out playerHit, .5f))
            {
                if (playerHit.transform.CompareTag("Building"))
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
         else if (direction == 3)
         {
             Ray playerRay = new Ray(transform.position, transform.right);
             RaycastHit playerHit;

            if (Physics.Raycast(playerRay, out playerHit))
            {
                if (playerHit.transform.CompareTag("Player"))
                {
                    clickedCube = playerHit.transform.GetComponent<CharacterMovement>().RaycastDown();
                    RaycastDown();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (Physics.Raycast(playerRay, out playerHit, .5f))
            {
                if (playerHit.transform.CompareTag("Building"))
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
         else
         {
             return false;
         }


     }
}



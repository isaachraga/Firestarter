using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour
{
    bool burnt = false;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BurnBuilding()
    {
        if (!burnt)
        {
            burnt = true;
            mat.color = Color.black;
            //add scores
        }
    }

}

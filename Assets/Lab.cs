using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab : MonoBehaviour
{


    private void Start()
    {
        string n = "4";
        Change(n);
        //Change(ref n);
        Debug.Log(n);
    }


    void Change(string n)
    {
        n = "10";
    }


    void Change(ref string n)
    {
        n = "10";
    }
}

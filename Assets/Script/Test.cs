using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    // Use this for initialization

    private void Awake()
    {
        Debug.Log("Awake");
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    void Start()
    {


    }




// Update is called once per frame
void Update()
    {

    }


    public async void Func()
    {
      
    }


    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(1);
    }
    
}

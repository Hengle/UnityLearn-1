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
        Debug.Log("Start");


        Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

        var enumerator = keyValuePairs.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var current = enumerator.Current;
            Debug.Log(current.Key + "_" + current.Value);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}

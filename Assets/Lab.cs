using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Lab : MonoBehaviour
{
    private void Awake()
    {
       
    }
    private void Start()
    {
        this.transform.GetComponent<Toggle>().onValueChanged.AddListener(OnToggle);
    }

    private void OnToggle(bool arg0)
    {
        Debug.Log(arg0);
    }
}

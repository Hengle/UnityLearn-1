using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickButtonTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.transform.GetComponent<Button>().onClick.AddListener(OnButton);
    }

    private void OnButton()
    {
        Debug.Log(">>>>OnButton");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

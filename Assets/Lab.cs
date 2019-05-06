using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab : MonoBehaviour
{
    private List<string> _strList;

    private void Start()
    {
        _strList = new List<string>();

        for (int i = 0; i < 99999; i++)
        {
            _strList.Add("123123");
        }

        Debug.Log("List 初始化完成");
    }

    private void OnDisable()
    {
        
    }

    private void OnDestroy()
    {
        Debug.Log("释放List");
    }
}

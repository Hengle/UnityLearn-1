using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFactory : MonoBehaviour
{
    public static UIFactory Instance { get; private set; }

    private readonly string UIBASEPATH = "Prefabs/UI/";

    private void Awake()
    {
        Instance = this;
    }


    public BaseView GetUIView(string uiName)
    {
        GameObject original = Resources.Load<GameObject>(UIBASEPATH + uiName); //assetSerice
        GameObject go = Instantiate(original, GetUIParent());

        if (uiName == "SetView")
        {
            return go.GetComponent<SetView>();
        }
        else
        {
            return null;
        }
    }


    private Transform GetUIParent()
    {
        //根据UI的类型取父节点
        //if (_viewName == "set")
        //{
        //}
        return GameObject.Find("UICanvas").transform;
    }
}

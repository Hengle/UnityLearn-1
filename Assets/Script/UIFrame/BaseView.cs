using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBehaviour
{
    private readonly string UIBASEPATH = "Prefabs/UI/";
    protected string _viewName;
    public Transform UIParent;
    private Transform _view;

    public virtual void Show()
    {
        GameObject original = Resources.Load<GameObject>(UIBASEPATH + _viewName); //assetSerice
        _view = Instantiate(original, GetUIParent()).transform;
        _view.gameObject.SetActive(true);
        _view.localPosition = Vector3.zero;
        _view.localScale = Vector3.one;
    }

    public virtual void Hide()
    {
        _view.localScale = Vector3.zero;
        Destroy(_view.gameObject);
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

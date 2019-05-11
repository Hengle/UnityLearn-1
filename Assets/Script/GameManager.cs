using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIFactory _uIFactory;

    private void Awake()
    {
        _uIFactory = new UIFactory();
    }
    // Use this for initialization
    void Start()
    {
        Init();
    }


    private void Init()
    {
        ShowSetUI();
    }


    private void ShowSetUI()
    {
        //SetView setView = (SetView)_uIFactory.GetUIView("set");
        BaseView setView = _uIFactory.GetUIView("SetView");
        setView.Show();
    }
}

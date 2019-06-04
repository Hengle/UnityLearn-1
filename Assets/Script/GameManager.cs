using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private void Awake()
    {
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
        BaseView setView = UIFactory.Instance.GetUIView("SetView");
        setView.Show();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetView : BaseView
{

    public SetView()
    {
        _viewName = "SetView";
    }

    private void Awake()
    {
        Transform content = this.transform.Find("Content").transform;
        Button buttonClose = content.transform.Find("ButtonClose").GetComponent<Button>(); 
        Button buttonOK = content.transform.Find("ButtonOK").GetComponent<Button>(); 
        Toggle toggleSFX = content.Find("ToggleSFX").GetComponent<Toggle>();
        Toggle toggleBGM = content.Find("ToggleBGM").GetComponent<Toggle>();

        buttonClose.onClick.AddListener(OnButtonClose);
        buttonOK.onClick.AddListener(OnButtonOK);
        toggleSFX.onValueChanged.AddListener(OnToggleSFX);
        toggleBGM.onValueChanged.AddListener(OnToggleBGM);
    }

    private void OnToggleBGM(bool arg0)
    {
        throw new NotImplementedException();
    }

    private void OnToggleSFX(bool arg0)
    {
        throw new NotImplementedException();
    }

    private void OnButtonClose()
    {
        Hide();
    }

    private void OnButtonOK()
    {


        Hide();
    }

}

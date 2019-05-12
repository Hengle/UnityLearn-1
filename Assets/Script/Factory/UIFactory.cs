using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFactory : MonoBehaviour
{
    public static UIFactory Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public BaseView GetUIView(string uiName)
    {
        if (uiName == "SetView")
        {
            return new SetView();
        }
        else
        {
            return null;
        }
    }
}

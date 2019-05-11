using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFactory : MonoBehaviour
{

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

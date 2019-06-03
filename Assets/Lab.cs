using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab : MonoBehaviour
{


    private void Start()
    {

        //#CC00FF
        //255 180 0 0

        Debug.Log(UnityExtension.HtmlStringToRGBA("#FF0000FF"));

        Debug.Log(UnityExtension.RGBAToHtmlString(UnityExtension.HtmlStringToRGBA("#FF0000FF")));

    }


}

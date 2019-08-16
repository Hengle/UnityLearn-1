using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Lab : MonoBehaviour
{
    public Image _image;
    private readonly string url = "http://192.168.1.243:8082/basketball/head_frame/8.png";

    private void Start()
    {
        //string str = LanguageService.Instance.GetString(Module.Common, "yes");
        //Debug.Log(str);
        //string str1 = LanguageService.Instance.GetString(Module.Module1, "module1");
        //Debug.Log(str1);


        //StartCoroutine(AssetsService.Instance.DownTexture(url, false, (sprite) =>
        // {
        //     _image.sprite = sprite;
        // }));

        Fun();
    }


    private async void Fun()
    {
        await AssetsService.Instance.DownTexture(url, false, (sprite) =>
        {
            _image.sprite = sprite;
        });
    }

    private void Fun1()
    {

    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            LuaService.Instance.LoadLuaScript();
            Play();
        }
    }

    [ContextMenu("Play")]
    private void Play()
    {
        Debug.Log("do lua ");
        // do lua
    }

    private void Func()
    {
        Debug.Log("this message is form CSharp....");
    }
}

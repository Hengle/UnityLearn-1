using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Lab : MonoBehaviour, IPointerEnterHandler
{
    public Image _image;
    private readonly string url = "http://192.168.1.243:8082/basketball/head_frame/8.png";

    private async void Start()
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

        //GetInfoAsync()


        Debug.Log("1");
        await Task.Delay(1000);
        Debug.Log("2");
        await Task.Delay(1000);
        Debug.Log("3");
        await Task.Delay(1000);
        Debug.Log("4");
        await SetAsync();
        Debug.Log("4444444444444");
    }


    private async void Fun()
    {
        //await AssetsService.Instance.DownTexture(url, false, (sprite) =>
        //{
        //    _image.sprite = sprite;
        //});
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


    public async static void GetInfoAsync()
    {
        await GetData();
        await GetData<int>(1);
        Debug.Log(222);
    }


    static Task GetData()
    {
        Debug.Log(000);
        return null;
    }

    static Task<T> GetData<T>(int a)
    {
        Debug.Log(111);
        return null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }


    public async Task SetAsync()
    {
        Debug.Log(00000000000000);


        await Task.Delay(4 * 1000);

        Debug.Log(1111);
    }
}

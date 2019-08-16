using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AssetsService : MonoBehaviour
{
    public static AssetsService Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <param name="cache"></param>
    /// <returns></returns>
    public IEnumerator DownTexture(string url, bool cache = false, Action<Sprite> action = null)
    {
        //如果本地存在
        //...
        UnityWebRequest request = new UnityWebRequest(url);
        DownloadHandlerTexture handler = new DownloadHandlerTexture(true);
        request.downloadHandler = handler;
        yield return request.SendWebRequest();
        if (string.IsNullOrEmpty(request.error))
        {
            Texture2D texture = handler.texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
            action?.Invoke(sprite);
            if (cache)
            {
                //写入本地
            }
        }
        request.Dispose();
        handler.Dispose();
    }


    IEnumerator DownAssetBundle<T>(string resName, string url) where T : UnityEngine.Object
    {
        UnityWebRequest unityWebRequest = UnityWebRequestAssetBundle.GetAssetBundle("url");
        yield return unityWebRequest.SendWebRequest();
        AssetBundle assetBundle = (unityWebRequest.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        T gameObject = assetBundle.LoadAsset<T>(resName);
    }


    public IEnumerator DownAsset(string url, bool cache = false)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (!string.IsNullOrEmpty(request.error))
        {
            Debug.LogError(request.error);

        }
        else
        {
            //request.downloadHandler.
            if (cache)
            {
                //写入本地
            }
        }
    }

    //public T LoadAssetAsyn<T>(string path) where T : UnityEngine.Object
    //{
    //    if (Config.LoadAssetType.Equals(LoadAssetType.Resources))
    //    {

    //    }
    //    else
    //    {
    //        //WWW加载
    //        return null;
    //    }
    //}

    public T LoadAsset<T>(string path) where T : UnityEngine.Object
    {
        return Resources.Load<T>(path);
    }

    //private IEnumerator ResourceLoadAsync<T>(string path) where T : Object
    //{
    //    ResourceRequest asset = Resources.LoadAsync<T>(path);
    //    yield return asset;
    //    Debug.Log(asset.asset.name + "load success");
    //}

    //IEnumerator LoadDynamicPrefab(string path, Action callback = null)
    //{
    //    ResourceRequest r = Resources.LoadAsync(path, typeof(UnityEngine.Object));
    //    while (!r.isDone)
    //    {
    //        yield return null;
    //    }
    //}

    //private T ResourceLoad<T>(string path) where T : Object
    //{
    //    return Resources.Load<T>(path);
    //}


    //public void Dispose()
    //{
    //    Resources.UnloadUnusedAssets();
    //}

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path">path的命名规则应该为 资源类型/业务/资源名称 例如：Texture/Ranking/icon </param>
    /// <returns></returns>
    //public T LoadAssetAsync<T>(string path) where T : Object
    //{
    //    //异步加载
    //    if (AppBaseData.environment.Equals(Environment.Dev))
    //    {
    //        return Resources.LoadAsync<T>(AppBaseData.PLATFORM + "/" + path);
    //    }
    //    else
    //    {

    //    }
    //}


    //public static T LoadAsset<T>(string path) where T : Object
    //{

    //    if (AppBaseData.environment.Equals(Environment.Dev))
    //    {
    //        return Resources.Load<T>(AppBaseData.PLATFORM + "/" + path);
    //    }
    //    else
    //    {

    //    }
    //}
}

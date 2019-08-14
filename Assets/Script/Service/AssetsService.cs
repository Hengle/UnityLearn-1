using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsService : MonoBehaviour
{
    public static AssetsService Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
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

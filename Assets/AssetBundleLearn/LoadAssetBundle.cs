using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssetBundle : MonoBehaviour
{
    public string Name1 = "cube";
    public string Name2 = "cube1";
    public string Path1 = @"D:\wangzuxiong\UnityLearn\Assets\AssetBundleLearn\AssetBundles\cube";
    public string Path2 = @"D:\wangzuxiong\UnityLearn\Assets\AssetBundleLearn\AssetBundles\cube1";

    private void Start()
    {
        StartCoroutine(DownAssetBundle<GameObject>(Name1, Path1));
        StartCoroutine(DownAssetBundle<GameObject>(Name2, Path2));
    }

    private IEnumerator DownAssetBundle<T>(string resName, string url) where T : Object
    {
        UnityWebRequest unityWebRequest = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return unityWebRequest.SendWebRequest();
        AssetBundle assetBundle = (unityWebRequest.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        Debug.LogError(assetBundle == null);
        T gameObject = assetBundle.LoadAsset<T>(resName);
        Instantiate(gameObject, Camera.main.transform);
    }
}

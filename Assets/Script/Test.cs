using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    // Use this for initialization

    private void Awake()
    {
        Debug.Log("Awake");
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    void Start()
    {

        downloadButton.Clicked += async (o, e) =>
        {
            // This line will yield control to the UI as the request
            // from the web service is happening.
            //
            // The UI thread is now free to perform other work.
            var stringData = await _httpClient.GetStringAsync(URL);
            DoSomethingWithData(stringData);
        };
    }
    //https://docs.microsoft.com/en-us/dotnet/csharp/async#feedback
    private readonly HttpClient _httpClient = new HttpClient();




// Update is called once per frame
void Update()
    {

    }


    public async void Func()
    {
      
    }


    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(1);
    }
    
}

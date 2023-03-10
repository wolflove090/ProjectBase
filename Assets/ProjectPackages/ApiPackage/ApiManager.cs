using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiManager
{
    public static IEnumerator GetRequest(string url, System.Action<string> onComplete, System.Action onError)
    {
        using(UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if(webRequest.isNetworkError)
            {
                Debug.Log("error = " + webRequest.error);
                onError?.Invoke();
            }
            else
            {
                Debug.Log("sucess = " + webRequest.downloadHandler.text);
                onComplete?.Invoke(webRequest.downloadHandler.text);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiManager : MonoBehaviour
{

    IEnumerator GetRequest()
    {
        string url = "";

        using(UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if(webRequest.isNetworkError)
            {
                Debug.Log("error = " + webRequest.error);
            }
            else
            {
                Debug.Log("sucess = " + webRequest.downloadHandler.text);
            }
        }
    }
}

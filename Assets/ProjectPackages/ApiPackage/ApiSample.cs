using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiSample : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ApiManager.GetRequest("", null, null));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsvPackageSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var csvData = CsvToStruct.LoadAll<TestCsv>();
        Debug.Log(csvData);
        foreach(var data in csvData)
        {
            Debug.Log(data.Name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

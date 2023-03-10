using UnityEngine;

[CsvFilePathAtrribute("master_test")]
public class TestCsv
{
    [CsvColumnAtrribute("id")]
    public string Id;

    [CsvColumnAtrribute("name")]
    public string Name;

    [CsvColumnAtrribute("description")]
    public string Descrip;
}

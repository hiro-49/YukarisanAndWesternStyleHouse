using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//csvを読み込んでList<string[]>の型で返す
public static class MyCSVReader
{
    static string path = "Assets/Common/Scenario/";

    public static List<string[]> LoadCSV(string fileName)
    {
        List<string[]> csvData = new List<string[]>();
        string csvFile = File.ReadAllText(path + fileName + ".csv");
        //1行ずつ読み込んでくれるクラスに入れる
        StringReader reader = new StringReader(csvFile);
        //最後の行まで繰り返す
        while(reader.Peek() != -1)
        {
            string line = reader.ReadLine();    //1行分読み込み
            csvData.Add(line.Split(','));   //カンマで区切った配列をリストに追加
        }
        return csvData;
    }
}

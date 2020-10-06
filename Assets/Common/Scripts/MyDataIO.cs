using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MyDataIO {
	static string path = "Assets/Common/SaveData/savedata.json";

    //jsonからData型を読み取り返す
	public static Data LoadData(){
		//ファイルがなければ作る
		if(!File.Exists(path)){
			//ファイル作成処理
			GameManager.Instance.CreateNewData();
			SaveData();
		}
        //ファイルを読み込む
		string json = File.ReadAllText(path);
		return JsonUtility.FromJson<Data>(json);
	}
    
    //Data型からjsonを作成する
	public static void SaveData(){
		string json = JsonUtility.ToJson(GameManager.Instance.data);
		File.WriteAllText(path, json);
	}
}

//Data型のルール
//class宣言時に[Serializable]をつける   要using System;
//記録するフィールドをpublicにする

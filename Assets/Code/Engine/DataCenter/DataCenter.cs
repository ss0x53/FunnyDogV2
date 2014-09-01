// Author : Frederic
// Date   : 2014-09-01
// Doc    : 数据的保存，写入等控制

using UnityEngine;
using System.Collections;

public class DataCenter {

    static public void WriteDataToFile(string filePath, string data)
    {

    }

    static public string LoadDataFromFile(string filePath)
    {

        return string.Empty;
    }


    static public string ObjectToJsonStr<T>(object obj)
    {

        return string.Empty;
    }

    static public T JsonStrToObject<T>(string str)
    {
        T t = default(T);
        return t;        
    }
	
}

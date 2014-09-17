// Author : Frederic
// Date   : 2014-09-01
// Doc    : 相关资源的加载，路径控制，等

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AssetsManager {
    Dictionary<string, GameObject> originAssets = new Dictionary<string, GameObject>();

    public GameObject GetGameObject(string path, string name)
    {
        if (!originAssets.ContainsKey(name))
        {
            GameObject origin = Resources.Load(path + name) as GameObject;
            originAssets.Add(name, origin);
        }
        GameObject obj = GameObject.Instantiate(originAssets[name]) as GameObject;
        return obj;
    }
    

}

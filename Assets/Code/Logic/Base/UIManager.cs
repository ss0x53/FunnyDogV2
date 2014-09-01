// Author : Frederic
// Date   : 2014-09-01
// Doc    : UI的全局管理，加载，销毁等

using UnityEngine;
using System.Collections;

public class UIManager {

    public void Init()
    {
        LoadStaticUI();
    }


    void LoadStaticUI()
    {

    }


    public void RegisterOnClickEvent(UIEventListener.VoidDelegate callback, string buttonName)
    {
        GameObject button = GameObject.Find(buttonName);
        UIEventListener.Get(button).onClick = (UIEventListener.VoidDelegate)callback;
    }

	
}

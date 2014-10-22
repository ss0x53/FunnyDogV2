using UnityEngine;
using System.Collections;

public class ADController : MonoBehaviour {

    AndroidJavaClass jc;
    AndroidJavaObject jo;
    bool isShowAD = false;
 
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        }

        StartCoroutine(SetShowADSign());
    }


    IEnumerator SetShowADSign()
    {
        WWW www = new WWW("http://www.argamente.com/FunnyDogADSwitch.html");
        yield return www;
        if (www.error == null)
        {
            if (www.text == "1")
            {
                isShowAD = true;
            }
        }
    }

    void AdShowCallback(string code)
    {
        if (code == "0")              // Show Successful
        {
            //debugInfo += "\nShow Successful";
        }
        else if (code == "-1")        // Show Faild
        {
            //debugInfo += "\nShow Faild";
        }
        else if (code == "2")         // ad Close
        {
            //debugInfo += "AD Close";
        }
    }


    public void ShowAD()
    {
        if (!isShowAD) { return; }
        jo.Call("ShowAd");
    }

    public void AndroidExit()
    {
        jo.Call("AndroidExit");
    }

}

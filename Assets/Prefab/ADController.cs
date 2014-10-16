using UnityEngine;
using System.Collections;

public class ADController : MonoBehaviour {

    AndroidJavaClass jc;
    AndroidJavaObject jo;
 
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
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
        jo.Call("ShowAd");
    }

}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class UICameraFit : MonoBehaviour {
    private float screen_x = 0;
    private float screen_y = 0;
    private float origin_x = 720;
    private float origin_y = 1280;

	// Use this for initialization
	void Start () {
        float x_proportion = origin_x / Screen.width;
        float y_proportion = origin_y / Screen.height;
        if (x_proportion != y_proportion)
        {
            camera.orthographicSize = (x_proportion + y_proportion) / 2;
        }
        else
        {
            camera.orthographicSize = x_proportion;
        }
        Debug.Log(x_proportion + "    " + y_proportion + "    " + Screen.width + "    " + Screen.height);
	}

}

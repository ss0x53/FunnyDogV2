using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
        
		}

		public bool isShowBegin = false;
		void Update ()
		{
				if (isShowBegin) {
						isShowBegin = false;
						GetComponent<EffectFader> ().Fade (enFadeType.Fade_Color, new Color (1, 1, 1, 1), 0.05f);
				}
		}



  
}

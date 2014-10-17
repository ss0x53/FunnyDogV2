using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
    public void Init()
    {
        GameObject backGroundMusic = new GameObject();
        AudioSource audio = backGroundMusic.AddComponent<AudioSource>();
        audio.clip = Resources.Load("BackMusic.m4a") as AudioClip;
        audio.loop = true;
        audio.Play();
    }

	
}

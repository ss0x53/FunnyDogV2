using UnityEngine;
using System.Collections;

public class IGameMenuController : MonoBehaviour {

    public GameObject button_Play = null;
    public GameObject button_About = null;

	
	void Start () {
        UIEventListener.Get(button_Play).onClick = BTN_Play;
        UIEventListener.Get(button_About).onClick = BTN_About;
	}

    void BTN_Play(GameObject go)
    {
        GlobalManager.Instance.GetGameManager.SwitchGameState(enGameState.GameState_GameMainMenu, enGameState.GameState_GamePlay);
    }

    void BTN_About(GameObject go)
    {
        GlobalManager.Instance.GetGameManager.SwitchGameState(enGameState.GameState_GameMainMenu, enGameState.GameState_GameAbout);
    }


}

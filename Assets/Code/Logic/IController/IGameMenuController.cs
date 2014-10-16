using UnityEngine;
using System.Collections;

public class IGameMenuController : MonoBehaviour {

    public GameObject button_Continue = null;
    public GameObject button_NewGame = null;
    public GameObject button_About = null;

	
	void Start () {
        UIEventListener.Get(button_Continue).onClick = BTN_Continue;
        UIEventListener.Get(button_NewGame).onClick = BTN_NewGame;
        UIEventListener.Get(button_About).onClick = BTN_About;
	}


    void BTN_Continue(GameObject go)
    {
        // Some code here
        GlobalManager.Instance.GetGameManager.SwitchGameState(enGameState.GameState_GameMainMenu, enGameState.GameState_GamePlay); 
    }


    void BTN_NewGame(GameObject go)
    {
        GlobalManager.Instance.GetDataManager.ClearGameData();
        GlobalManager.Instance.GetGameManager.SwitchGameState(enGameState.GameState_GameMainMenu, enGameState.GameState_GamePlay);
    }

    void BTN_About(GameObject go)
    {
        GlobalManager.Instance.GetGameManager.SwitchGameState(enGameState.GameState_GameMainMenu, enGameState.GameState_GameAbout);
    }


}

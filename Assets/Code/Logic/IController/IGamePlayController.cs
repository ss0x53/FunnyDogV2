using UnityEngine;
using System.Collections;

public class IGamePlayController : MonoBehaviour {
    public GameObject button_ArrowRight = null;
    public GameObject button_ArrowDown = null;
    public GameObject button_Clear = null;
    public GameObject button_Go = null;
    public GameObject button_About = null;

	void Start () {
        UIEventListener.Get(button_ArrowRight).onClick  = BTN_ArrowRight;
        UIEventListener.Get(button_ArrowDown).onClick   = BTN_ArrowDown;
        UIEventListener.Get(button_Clear).onClick       = BTN_Clear;
        UIEventListener.Get(button_Go).onClick          = BTN_Go;
        UIEventListener.Get(button_About).onClick       = BTN_About;
	}


    void BTN_ArrowRight(GameObject go)
    {
        GlobalManager.Instance.GetGameController.AddPathDir(enPathDir.Right);
    }

    void BTN_ArrowDown(GameObject go)
    {
        GlobalManager.Instance.GetGameController.AddPathDir(enPathDir.Down);
    }

    void BTN_Clear(GameObject go)
    {
        GlobalManager.Instance.GetGameController.RemoveDir();
    }

    void BTN_Go(GameObject go)
    {
        GlobalManager.Instance.GetGameController.GameStart();
    }

    void BTN_About(GameObject go)
    {
        enGameState currentGameState = GlobalManager.Instance.GetGameManager.GetCurrentGameState();
        GlobalManager.Instance.GetGameManager.SwitchGameState(currentGameState, enGameState.GameState_GameAbout);
    }
	

}

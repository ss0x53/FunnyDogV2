using UnityEngine;
using System.Collections;

public class IGameIfExitController : MonoBehaviour {
    public GameObject button_Quit = null;
    public GameObject button_Cancel = null;

    void Start()
    {
        UIEventListener.Get(button_Quit).onClick = BTN_Quit;
        UIEventListener.Get(button_Cancel).onClick = BTN_Cancel;
    }


    void BTN_Quit(GameObject go)
    {
        GlobalManager.Instance.GetGameController.GameQuit();
    }

    void BTN_Cancel(GameObject go)
    {
        GlobalManager.Instance.GetGameManager.SwitchGameState(enGameState.GameState_GameIfQuit, enGameState.GameState_GamePlay);
    }

	
}

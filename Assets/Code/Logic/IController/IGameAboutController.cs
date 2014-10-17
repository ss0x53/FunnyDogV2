using UnityEngine;
using System.Collections;

public class IGameAboutController : MonoBehaviour {

    void Start()
    {
        GlobalManager.adKillCode = 0;
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            enGameState targetState = GlobalManager.Instance.GetGameManager.GetPrevGameState();
            GlobalManager.Instance.GetGameManager.SwitchGameState(enGameState.GameState_GameAbout, targetState);
        }

        if (Input.GetMouseButtonDown(0))
        {
            ++GlobalManager.adKillCode;
        }
	
	}
}

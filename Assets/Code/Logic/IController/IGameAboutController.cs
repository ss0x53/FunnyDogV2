using UnityEngine;
using System.Collections;

public class IGameAboutController : MonoBehaviour {

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            enGameState targetState = GlobalManager.Instance.GetGameManager.GetPrevGameState();
            GlobalManager.Instance.GetGameManager.SwitchGameState(enGameState.GameState_GameAbout, targetState);
        }
	
	}
}

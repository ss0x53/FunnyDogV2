using UnityEngine;
using System.Collections;

public class IGameAboutController : MonoBehaviour {

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            enGameState targetState = GlobalManager.Instance.GetGameManager.GetPrevGameState();
            Debug.Log("SHit........" + targetState);
            GlobalManager.Instance.GetGameManager.SwitchGameState(enGameState.GameState_GameAbout, targetState);
        }
	
	}
}

using UnityEngine;
using System.Collections;

public class IGameLogoContrller : MonoBehaviour {

	void Start () {
        Invoke("GotoMainMenu", 1f);
	}


    public void GotoMainMenu()
    {
        GlobalManager.Instance.GetGameManager.SwitchGameState(enGameState.GameState_GameLogo, enGameState.GameState_GamePlay);
    }
	
}

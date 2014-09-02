using UnityEngine;
using System.Collections;

public enum enGameState
{
    GameState_None = -1,
    GameState_CompanyLogo,
    GameState_GameLogo,
    GameState_GameMainMenu,
    GameState_GamePlay,
    GameState_GameAbout,
    GameState_Max,

}


public class GameManager {
    enGameState m_enCurrentGameState;
    enGameState m_enTargetGameState;

    public void Init()
    {
        m_enCurrentGameState = enGameState.GameState_None;
        m_enTargetGameState = enGameState.GameState_CompanyLogo;
    }


    public void SetCurrentGameState(enGameState gameState)
    {
        m_enCurrentGameState = gameState;
    }

    public void SetTargetGameState(enGameState gameState)
    {
        m_enTargetGameState = gameState;
    }

    public enGameState GetCurrentGameState()
    {
        return m_enCurrentGameState;
    }

    public enGameState GetTargetGameState()
    {
        return m_enTargetGameState;
    }


    public void SwitchGameState(enGameState enOldGameState, enGameState enNewGameState)
    {
        switch (enOldGameState)
        {
            case enGameState.GameState_None:
                {
                    switch (enNewGameState)
                    {
                        case enGameState.GameState_CompanyLogo:
                            {
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_CompanyLogo);
                                SetCurrentGameState(enGameState.GameState_CompanyLogo);
                                SetTargetGameState(enGameState.GameState_GameLogo);
                            }
                            break;
                    }
                }
                break;
            case enGameState.GameState_CompanyLogo:
                {
                    switch (enNewGameState)
                    {
                        case enGameState.GameState_GameLogo:
                            {
                                GlobalManager.Instance.GetUIManager.RemoveInterface(enInterfaceName.InterfaceName_CompanyLogo);
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_GameLogo);
                                SetCurrentGameState(enGameState.GameState_GameLogo);
                                SetTargetGameState(enGameState.GameState_GameMainMenu);
                            }
                            break;
                    }
                }
                break;
            case enGameState.GameState_GameLogo:
                {
                    switch (enNewGameState)
                    {
                        case enGameState.GameState_GameMainMenu:
                            {
                                GlobalManager.Instance.GetUIManager.RemoveInterface(enInterfaceName.InterfaceName_GameLogo);
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_GameMainMenu);
                                SetCurrentGameState(enGameState.GameState_GameMainMenu);
                            }
                            break;
                    }
                }
                break;
            case enGameState.GameState_GameMainMenu:
                {
                    switch (enNewGameState)
                    {
                        case enGameState.GameState_GamePlay:
                            {
                                GlobalManager.Instance.GetUIManager.RemoveInterface(enInterfaceName.InterfaceName_GameMainMenu);
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_GamePlay);
                                SetCurrentGameState(enGameState.GameState_GamePlay);
                            }
                            break;
                        case enGameState.GameState_GameAbout:
                            {
                                GlobalManager.Instance.GetUIManager.RemoveInterface(enInterfaceName.InterfaceName_GameMainMenu);
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_GameAbout);
                                //SetCurrentGameState(enGameState.GameState_GameAbout);



                            }
                            break;
                    }
                }
                break;
            case enGameState.GameState_GamePlay:
                {

                }
                break;
            case enGameState.GameState_GameAbout:
                {

                }
                break;
            default: break;
        }
    }

	
}

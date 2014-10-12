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
    GameState_GameIfQuit,
    GameState_Max,

}


public class GameManager {
    enGameState m_enPrevGameState;
    enGameState m_enCurrentGameState;
    enGameState m_enTargetGameState;

    public void Init()
    {
        m_enPrevGameState = enGameState.GameState_None;
        m_enCurrentGameState = enGameState.GameState_None;
        m_enTargetGameState = enGameState.GameState_CompanyLogo;
    }


    public void SetPrevGameState(enGameState gameState)
    {
        m_enPrevGameState = gameState;
    }

    public void SetCurrentGameState(enGameState gameState)
    {
        m_enCurrentGameState = gameState;
    }

    public void SetTargetGameState(enGameState gameState)
    {
        m_enTargetGameState = gameState;
    }


    public enGameState GetPrevGameState()
    {
        return m_enPrevGameState;
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
        SetPrevGameState(enOldGameState);
        switch (enOldGameState)
        {
            case enGameState.GameState_None:                        // Game Execute
                {
                    switch (enNewGameState)
                    {
                        case enGameState.GameState_CompanyLogo:     // Go to company logo
                            {
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_CompanyLogo);
                                SetCurrentGameState(enGameState.GameState_CompanyLogo);
                                SetTargetGameState(enGameState.GameState_GameLogo);
                            }
                            break;
                    }
                }
                break;
            case enGameState.GameState_CompanyLogo:                 // current is company logo
                {
                    switch (enNewGameState)
                    {
                        case enGameState.GameState_GameLogo:        // go to game logo
                            {
                                GlobalManager.Instance.GetUIManager.RemoveInterface(enInterfaceName.InterfaceName_CompanyLogo);
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_GameLogo);
                                SetCurrentGameState(enGameState.GameState_GameLogo);
                                SetTargetGameState(enGameState.GameState_GameMainMenu);
                            }
                            break;
                        case enGameState.GameState_GameMainMenu:
                            {
                                GlobalManager.Instance.GetUIManager.RemoveInterface(enInterfaceName.InterfaceName_CompanyLogo);
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_GameMainMenu);
                                SetCurrentGameState(enGameState.GameState_GameMainMenu);
                            }
                            break;
                    }
                }
                break;
            case enGameState.GameState_GameLogo:                    // current is game logo
                {
                    switch (enNewGameState)
                    {
                        case enGameState.GameState_GameMainMenu:    // go to main menu 
                            {
                                GlobalManager.Instance.GetUIManager.RemoveInterface(enInterfaceName.InterfaceName_GameLogo);
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_GameMainMenu);
                                SetCurrentGameState(enGameState.GameState_GameMainMenu);
                            }
                            break;
                    }
                }
                break;
            case enGameState.GameState_GameMainMenu:                // current is main menu
                {
                    switch (enNewGameState)
                    {
                        case enGameState.GameState_GamePlay:        // go to game play
                            {
                                GlobalManager.Instance.GetUIManager.RemoveInterface(enInterfaceName.InterfaceName_GameMainMenu);
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_GamePlay);
                                SetCurrentGameState(enGameState.GameState_GamePlay);
                            }
                            break;
                        case enGameState.GameState_GameAbout:       // go to about
                            {
                                GlobalManager.Instance.GetUIManager.RemoveInterface(enInterfaceName.InterfaceName_GameMainMenu);
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_GameAbout);
                                SetCurrentGameState(enGameState.GameState_GameAbout);
                                SetTargetGameState(enGameState.GameState_GameMainMenu);
                            }
                            break;
                    }
                }
                break;
            case enGameState.GameState_GamePlay:                    // current is game play
                {
                    switch (enNewGameState)
                    {
                        case enGameState.GameState_GameAbout:       // go to about
                            {
                                GlobalManager.Instance.GetUIManager.DisableInterface(enInterfaceName.InterfaceName_GamePlay);
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_GameAbout);
                                SetCurrentGameState(enGameState.GameState_GameAbout);
                                SetTargetGameState(enGameState.GameState_GamePlay);
                            }
                            break;
                        case enGameState.GameState_GameMainMenu:    // go to main menu
                            {
                                GlobalManager.Instance.GetUIManager.RemoveInterface(enInterfaceName.InterfaceName_GamePlay);
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_GameMainMenu);
                                SetCurrentGameState(enGameState.GameState_GameMainMenu);
                            }
                            break;
                        case enGameState.GameState_GameIfQuit:
                            {
                                GlobalManager.Instance.GetGameController.GamePause();
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_GameIfExit);
                                SetCurrentGameState(enGameState.GameState_GameIfQuit);
                            }
                            break;
                        case enGameState.GameState_GamePlay:
                            GlobalManager.Instance.GetUIManager.RemoveInterface(enInterfaceName.InterfaceName_GamePlay);
                            GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_GamePlay);
                            SetCurrentGameState(enGameState.GameState_GamePlay);
                            break;
                    }
                }
                break;
            case enGameState.GameState_GameAbout:                   // current is game about
                {
                    switch (enNewGameState)
                    {
                        case enGameState.GameState_GamePlay:         // go to game play
                            {
                                GlobalManager.Instance.GetUIManager.RemoveInterface(enInterfaceName.InterfaceName_GameAbout);
                                GlobalManager.Instance.GetUIManager.EnableInterface(enInterfaceName.InterfaceName_GamePlay);
                                SetCurrentGameState(enGameState.GameState_GamePlay);
                            }
                            break;
                        case enGameState.GameState_GameMainMenu:    // go to game main menu
                            {
                                GlobalManager.Instance.GetUIManager.RemoveInterface(enInterfaceName.InterfaceName_GameAbout);
                                GlobalManager.Instance.GetUIManager.AddInterface(enInterfaceName.InterfaceName_GameMainMenu);
                                SetCurrentGameState(enGameState.GameState_GameMainMenu);
                            }
                            break;
                    }
                }
                break;
            case enGameState.GameState_GameIfQuit:
                switch (enNewGameState)
                {
                    case enGameState.GameState_GamePlay:
                        {
                            GlobalManager.Instance.GetUIManager.RemoveInterface(enInterfaceName.InterfaceName_GameIfExit);
                            GlobalManager.Instance.GetGameController.GameResume();
                            SetCurrentGameState(enGameState.GameState_GamePlay);
                        }
                        break;
                    case enGameState.GameState_GameIfQuit:
                        {
                            SwitchGameState(enGameState.GameState_GameIfQuit, enGameState.GameState_GamePlay);
                        }
                        break;
                }
                break;
            default: break;
        }
    }

	
}

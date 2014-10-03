using UnityEngine;
using System.Collections;
using AGMAlgorithm;

public class IGamePlayController : MonoBehaviour {
    public GameObject button_ArrowRight = null;
    public GameObject button_ArrowDown = null;
    public GameObject button_Clear = null;
    public GameObject button_Go = null;
    public PathGridIniter pathIniter = null;
    public ArrowGridIniter arrowGridIniter = null;
    public PlayerIniter playerIniter = null;
    public UILabel levelText = null;
    MapSolution_t levelData;

	void Start () {
        
        AllIniterInit();
	}

    void OnEnable()
    {
        GlobalManager.Instance.GetGameController.gameEndEvent += GameEndEventReceiver;
    }

    void OnDisable()
    {
        GlobalManager.Instance.GetGameController.gameEndEvent -= GameEndEventReceiver;
    }


    void RegeisterButtonEvent(bool isOk)
    {
        if (isOk)
        {
            UIEventListener.Get(button_ArrowRight).onClick = BTN_ArrowRight;
            UIEventListener.Get(button_ArrowDown).onClick = BTN_ArrowDown;
            UIEventListener.Get(button_Clear).onClick = BTN_Clear;
            UIEventListener.Get(button_Go).onClick = BTN_Go;
        }
        else
        {
            UIEventListener.Get(button_ArrowRight).onClick = null;
            UIEventListener.Get(button_ArrowDown).onClick = null;
            UIEventListener.Get(button_Clear).onClick = null;
            UIEventListener.Get(button_Go).onClick = null;
        }
    }


    void OnDestroy()
    {
        GlobalManager.Instance.GetGameController.gameEndEvent -= GameEndEventReceiver;
    }


    void GameEndEventReceiver()
    {
        AllIniterInit();
    }



    void AllIniterInit()
    {
        RegeisterButtonEvent(true);

        levelData = GlobalManager.Instance.GetGameController.GetLevelData();

        Vector3 pos = pathIniter.InitPath(levelData);
        arrowGridIniter.InitArrowGrid(levelData.maxStep);
        playerIniter.InitPlayer(pos);
        button_Go.SetActive(false);
        levelText.text = "Level: " + levelData.levelID;
    }


    void BTN_ArrowRight(GameObject go)
    {
        if (GlobalManager.Instance.GetGameController.AddPathDir(enPathDir.Right))
        {
            arrowGridIniter.AddArrow(enPathDir.Right);
        }

        if (GlobalManager.Instance.GetGameController.CanGo())
        {
            button_Go.SetActive(true);
        }
    }

    void BTN_ArrowDown(GameObject go)
    {
        if (GlobalManager.Instance.GetGameController.AddPathDir(enPathDir.Down))
        {
            arrowGridIniter.AddArrow(enPathDir.Down);
        }

        if (GlobalManager.Instance.GetGameController.CanGo())
        {
            button_Go.SetActive(true);
        }
    }

    void BTN_Clear(GameObject go)
    {
        if (GlobalManager.Instance.GetGameController.RemoveDir())
        {
            arrowGridIniter.RemoveArrow();
        }

        if (!GlobalManager.Instance.GetGameController.CanGo())
        {
            button_Go.SetActive(false);
        }
    }

    void BTN_Go(GameObject go)
    {
        Debug.Log("Click BTN GO");
        if (GlobalManager.Instance.GetGameController.GameStart())
        {
            RegeisterButtonEvent(false);
        }
    }

    void BTN_About(GameObject go)
    {
        enGameState currentGameState = GlobalManager.Instance.GetGameManager.GetCurrentGameState();
        GlobalManager.Instance.GetGameManager.SwitchGameState(currentGameState, enGameState.GameState_GameAbout);
    }
	

}

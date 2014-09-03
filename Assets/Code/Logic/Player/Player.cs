// Author : Frederic
// Date   : 2014-09-01
// Doc    : 玩家角色的控制

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    private List<enPathDir> myPath;
    private Vector3 originPos = Vector3.zero;

    void Start()
    {
        GlobalManager.Instance.GetGameController.gameStartEvent += Go;
        originPos = transform.localPosition;
    }


    public void SetPlayerOriginState()
    {
        transform.localPosition = originPos;
    }


    public void Go()
    {
        myPath = GlobalManager.Instance.GetGameController.GetPathDirs();
        StartCoroutine(ShowBegin());
    }


    public void GameOver(bool isWon)
    {
        GlobalManager.Instance.GetGameController.GameEnd(isWon);
    }


    IEnumerator ShowBegin()
    {




        yield return 0;
    }


    void OnEnable()
    {
        GlobalManager.Instance.GetGameController.gameStartEvent += Go;
    }

    void OnDisable()
    {
        GlobalManager.Instance.GetGameController.gameStartEvent -= Go;
    }	
}

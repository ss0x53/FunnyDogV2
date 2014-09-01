// Author : Frederic
// Date   : 2014-09-01
// Doc    : 玩家角色的控制

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    private List<pathDir_e> myPath;

    void Start()
    {
        GlobalManager.Instance.GetGameController.gameStartEvent += Go;
    }


    public void SetPlayerOriginState()
    {

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

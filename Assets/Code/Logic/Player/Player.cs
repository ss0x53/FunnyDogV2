// Author : Frederic
// Date   : 2014-09-01
// Doc    : 玩家角色的控制

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AGMAlgorithm;

public class Player : MonoBehaviour {

    private List<enPathDir> myPath;
    private Vector2 stepIndex = Vector2.zero;
    private MapSolution_t solution;
    private float stepMoveSize;
    void Start()
    {
        GlobalManager.Instance.GetGameController.gameStartEvent += Go;
    }


    void OnDestroy()
    {
        GlobalManager.Instance.GetGameController.gameStartEvent -= Go;
    }


    public void SetPlayerOriginState(Vector3 playerOriginPos)
    {
        transform.localPosition = new Vector3(playerOriginPos.x,0,0);
        stepMoveSize = playerOriginPos.z;
    }


    public void Go()
    {
        myPath = GlobalManager.Instance.GetGameController.GetPathDirs();
        solution = GlobalManager.Instance.GetGameController.GetLevelData();
        StartCoroutine(ShowBegin());
    }


    public void GameOver(bool isWon)
    {
        GlobalManager.Instance.GetGameController.GameEnd(isWon);
    }


    IEnumerator ShowBegin()
    {
        foreach (enPathDir dir in myPath)
        {
            if (dir == enPathDir.Right)
            {
                stepIndex.x += 1;
                Vector3 targetPos = transform.localPosition + new Vector3(stepMoveSize, 0, 0);
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, 0.3f);
            }
            else
            {
                stepIndex.y += 1;
                Vector3 targetPos = transform.localPosition + new Vector3(0, stepMoveSize, 0);
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, 0.3f);
            }

            if ((int)stepIndex.x == solution.mapWidth || (int)stepIndex.y == solution.mapHeight)
            {
                PlayerGameOverAnimation(true);
                break;
            }

            if (solution.mapMatrix[(int)stepIndex.y, (int)stepIndex.x] == 1)
            {
                PlayerGameOverAnimation(false);
                break;
            }

        }
        yield return 0;
    }



    IEnumerator PlayerGameOverAnimation(bool isWon)
    {
        if (isWon)
        {

        }
        else
        {

        }

        yield return new WaitForSeconds(1.5f);
        GameOver(isWon);
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

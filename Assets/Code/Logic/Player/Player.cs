// Author : Frederic
// Date   : 2014-09-01
// Doc    : 玩家角色的控制

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AGMAlgorithm;

public class Player : MonoBehaviour {
    public GameObject playerMesh = null;
    private List<enPathDir> myPath;
    //private Vector2 stepIndex = Vector2.zero;
    private int mapColIndex = 0;
    private int mapRowIndex = 0;
    private MapSolution_t solution;
    private float stepMoveSize;


    public void SetDimensions(int x, int y)
    {
        playerMesh.GetComponent<UISprite>().SetDimensions(x, y);
    }

    public void SetPlayerOriginState(Vector3 playerOriginPos)
    {
        transform.localPosition = new Vector3(playerOriginPos.x,0,0);
        //playerOriginPos.z;
    }

    public void SetStepMoveSize(int size)
    {
        stepMoveSize = size;
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
        int pathIndex = 0;
        enPathDir dir;
        bool isWon = false;
        while (true)
        {
            if (pathIndex == myPath.Count)
            {
                pathIndex = 0;
            }
            dir = myPath[pathIndex++];
            if (dir == enPathDir.Right)
            {
                ++mapColIndex;
                Vector3 targetPos = transform.localPosition + new Vector3(stepMoveSize, 0, 0);
                //transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, 0.3f);
                transform.localPosition = targetPos;
            }
            else
            {
                ++mapRowIndex;
                Vector3 targetPos = transform.localPosition + new Vector3(0, -stepMoveSize, 0);
                //transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, 0.3f);
                transform.localPosition = targetPos;
            }

            if (solution.mapMatrix[mapRowIndex, mapColIndex] == enGrid.Danger)
            {
                break;
            }

            if (solution.mapMatrix[mapRowIndex, mapColIndex] == enGrid.Won)
            {
                isWon = true;
                break;
            }
            yield return new WaitForSeconds(0.5f);
        }

        StartCoroutine(PlayerGameOverAnimation(isWon));


        yield return 0;
    } 



    IEnumerator PlayerGameOverAnimation(bool isWon)
    {
        if (isWon)
        {
            yield return new WaitForSeconds(0.5f);
            playerMesh.animation.Play("Anim_PlayerWon");
            yield return new WaitForSeconds(2.0f);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            transform.localEulerAngles = new Vector3(0, 0, -20);
            yield return new WaitForSeconds(0.6f);
            transform.localEulerAngles = new Vector3(0, 0, -90);
            transform.localPosition -= new Vector3(0, 60, 0);
            yield return new WaitForSeconds(1.0f);
        }

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

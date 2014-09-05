// Author : Frederic
// Date   : 2014-09-01
// Doc    : 游戏控制器，游戏世界的创建销毁，游戏状态的控制，游戏的整个流程控制。

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AGMAlgorithm;
public class GameController {

    public delegate void GameStartDelegate();
    public delegate void GameEndDelegate();
    public GameStartDelegate gameStartEvent;
    public GameEndDelegate gameEndEvent;

    private PathGridIniter pathIniter = null;
    private ArrowGridIniter arrowGridIniter = null;
    private PlayerIniter playerIniter = null;

    private List<enPathDir> pathDirs = new List<enPathDir>();
    MapSolution_t levelData;

    public void InitGame()
    {
        if ( !pathIniter || !arrowGridIniter || !playerIniter)
        {
            pathIniter = GameObject.FindGameObjectWithTag("Pathiniter").GetComponent<PathGridIniter>();
            arrowGridIniter = GameObject.FindGameObjectWithTag("ArrowGridIniter").GetComponent<ArrowGridIniter>();
            playerIniter = GameObject.FindGameObjectWithTag("PlayerIniter").GetComponent<PlayerIniter>();
        }

        int levelID = GlobalManager.Instance.GetDataManager.GetGameLevel();
        levelData = GlobalManager.Instance.GetLevelManager.GetLevelData(levelID);

        pathIniter.InitPath(levelData);
        arrowGridIniter.InitArrowGrid(levelData.maxStep);
        playerIniter.InitPlayer();
    }


    public void GameStart()
    {
        gameStartEvent();
    }


    public void GameEnd(bool isWon)
    {
        gameEndEvent();
        ClearGameData();
    }

    public void GamePause()
    {
        Time.timeScale = 0.0f;
    }

    public void GameResume()
    {
        Time.timeScale = 1.0f;
    }


    public bool AddPathDir(enPathDir dir)
    {
        if (pathDirs.Count < levelData.maxStep)
        {
            pathDirs.Add(dir);
            arrowGridIniter.AddArrow();
            return true;
        }
        return false;
    }


    public void RemoveDir()
    {
        if (pathDirs.Count > 0)
        {
            pathDirs.RemoveAt(pathDirs.Count - 1);
            arrowGridIniter.RemoveArrow();
        }
    }


    public List<enPathDir> GetPathDirs()
    {
        return pathDirs;
    }


    public void ClearGameData()
    {
        pathDirs.Clear();
    }


    public void GameQuit()
    {
        Application.Quit();    
    }
}



public enum enPathDir
{
    Right,
    Down,
}

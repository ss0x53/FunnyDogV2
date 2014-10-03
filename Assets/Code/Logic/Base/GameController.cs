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
    int levelID;


    public void InitGame()
    {
        pathDirs.Clear();
        levelID = GlobalManager.Instance.GetDataManager.GetGameLevel();
        levelData = GlobalManager.Instance.GetLevelManager.GetLevelData(levelID);
    }


    public bool GameStart()
    {
        if (pathDirs.Count >= levelData.minStep)
        {
            if (gameStartEvent != null)
            {
                gameStartEvent();
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }


    public void GameEnd(bool isWon)
    {
        if (isWon)
        {
            GlobalManager.Instance.GetDataManager.UpgradeData();
        }

        InitGame();
        GlobalManager.Instance.GetGameManager.SwitchGameState(enGameState.GameState_GamePlay, enGameState.GameState_GamePlay);
        //gameEndEvent();
        //ClearGameData();
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
            return true;
        }
        return false;
    }


    public bool RemoveDir()
    {
        if (pathDirs.Count > 0)
        {
            pathDirs.RemoveAt(pathDirs.Count - 1);
            return true;
        }
        return false;
    }


    public bool CanGo()
    {
        if (pathDirs.Count >= levelData.minStep)
        {
            return true;
        }
        return false;
    }


    public List<enPathDir> GetPathDirs()
    {
        return pathDirs;
    }


    public int GetLevelID()
    {
        return levelID;
    }


    public MapSolution_t GetLevelData()
    {
        return levelData;
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

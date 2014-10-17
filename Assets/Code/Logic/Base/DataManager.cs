// Author : Frederic
// Date   : 2014-09-01
// Doc    : 游戏数据保存及加载相关的逻辑控制

using UnityEngine;
using System.Collections;

public class DataManager {
    private GameData_t gameData = new GameData_t();

    public void Init()
    {
        LoadGameData();
    }


    public void UpgradeData()
    {
        gameData.currLevel += 1;
        SaveGameData();
    }


    public int GetGameLevel()
    {
        return gameData.currLevel;
    }


    public void LoadGameData()
    {
        if (PlayerPrefs.HasKey("GameLevel"))
        {
            gameData.currLevel = PlayerPrefs.GetInt("GameLevel");
        }
    }


    public void SaveGameData()
    {
        PlayerPrefs.SetInt("GameLevel", gameData.currLevel);

    }


    public void ClearGameData()
    {
        PlayerPrefs.DeleteAll();
    }

}

public class GameData_t
{
    public int currLevel;
}



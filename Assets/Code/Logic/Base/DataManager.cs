// Author : Frederic
// Date   : 2014-09-01
// Doc    : 游戏数据保存及加载相关的逻辑控制

using UnityEngine;
using System.Collections;
using System.IO;

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
        string path = GetPath() + "GameData";

        if (File.Exists(path))
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fs);
            string data = reader.ReadToEnd();
            reader.Close();
            fs.Close();
            gameData.currLevel = int.Parse(data);
        }


        //if (PlayerPrefs.HasKey("GameLevel"))
        //{
        //    gameData.currLevel = PlayerPrefs.GetInt("GameLevel");
        //}
    }


    public void SaveGameData()
    {
        string path = GetPath() + "GameData";

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        StreamWriter writer = new StreamWriter(File.Create(path));
        writer.Write(gameData.currLevel);
        writer.Close();
        writer.Dispose();
        //PlayerPrefs.SetInt("GameLevel", gameData.currLevel);
    }


    public void ClearGameData()
    {
        string path = GetPath() + "GameData";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        gameData.currLevel = 0;
    }


    public string GetPath()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            return Application.persistentDataPath + "/";
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            return Application.streamingAssetsPath + "/";
        }
        return null;
    }


}

public class GameData_t
{
    public int currLevel;
}



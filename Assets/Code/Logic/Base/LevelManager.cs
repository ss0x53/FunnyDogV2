// Author : Frederic
// Date   : 2014-09-01
// Doc    : 产生加载关卡数据，暂定为两种方式，程序生成及手动拼关卡

using UnityEngine;
using System.Collections;

public class LevelManager {

    public LevelData_t GetLevelData(int levelID)
    {
        // generate or load level data
        return new LevelData_t();
    }
}

public class LevelData_t
{
    public int[,] pathMatrix;
    public int width;
    public int height;
    public int arrowNumbers;
}

// Author : Frederic
// Date   : 2014-09-01
// Doc    : 产生加载关卡数据，暂定为两种方式，程序生成及手动拼关卡

using UnityEngine;
using System.Collections;

public class LevelManager {

    public MapSolution_t GetLevelData(int levelID)
    {
        int minStep = 0;
        int maxStep = 0;
        int mapWidth = 0;
        int mapheight = 0;
        int obstacleNumber = 0;
        
        MapSolution_t solution = new MapSolution_t(0,0,0,0,0);
        return solution;
    }
}

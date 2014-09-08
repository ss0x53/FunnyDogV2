// Author : Frederic
// Date   : 2014-09-01
// Doc    : 产生加载关卡数据，暂定为两种方式，程序生成及手动拼关卡

using UnityEngine;
using System.Collections;
using AGMAlgorithm;
public class LevelManager {

    public MapSolution_t GetLevelData(int levelID)
    {
        MapSolution_t solution = new MapSolution_t(levelID);
        return solution;
    }
}

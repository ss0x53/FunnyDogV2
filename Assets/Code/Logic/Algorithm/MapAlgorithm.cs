using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AGMAlgorithm
{
    public class MapSolution_t
    {
        public int levelID = 0;
        public int maxStep = 0;          // 网格宽度 / 2 向上取整
        public int minStep = 0;          // 最大步数 / 2 向上取整
        public int obstacleNumber = 0;   // 障碍数量 = 可走网格总数是障碍数量的3~5倍，随机
        public int mapWidth = 0;         // 根据起始网格数，每完成一次循环，网格宽度+1
        public int mapHeight = 0;
        public int[,] mapMatrix;        // 0 is available grid, 1 is obstacle, -1 is Player path, 2 is Won Grid
        public int[] solution;          // 1 is to right, 2 is to down


        private int startGridNumber = 4;
        private int startLoopOfGridNumber = 2;
        private float minMultiple = 3;
        private float maxMultiple = 5;


        public MapSolution_t(int levelID)
        {
            this.levelID = levelID;
            this.mapWidth = CalcGridNumbersByLevelID();
            this.mapHeight = this.mapWidth;
            this.maxStep = Mathf.CeilToInt(this.mapWidth / 2.0f);
            this.minStep = Mathf.CeilToInt(this.maxStep / 2.0f);
            this.obstacleNumber = CalcObstacleNumberByGridNumbers();
            
            GenerateSolution();
            GenerateMap();
        }

        private void GenerateSolution()
        {
            Random.seed = (int)Time.realtimeSinceStartup;
            int solutionStep = Random.Range(this.minStep, this.maxStep + 1);
            solution = new int[solutionStep];

            for (int i = 0; i < solution.Length; ++i)
            {
                if (Random.value > 0.5f)    
                {
                    solution[i] = 1;        // Walk to right
                }
                else
                {
                    solution[i] = 2;        // Walk to down
                }
            }


            // 检查是所有行走路径是否全一样
            int rightNumbers = 0;
            for (int i = 0; i < solution.Length; ++i)
            {
                if (solution[i] == 1)
                {
                    ++rightNumbers;
                }
            }

            // 若所有路径全一样，则改变其中的30%为另一个方向
            if (rightNumbers == solution.Length)         // all is walk to right
            {
                int changeNumbers = Mathf.CeilToInt(solution.Length * 0.3f);
                List<int> indexs = new List<int>();
                for (int i = 0; i < solution.Length; ++i)
                {
                    indexs.Add(i);
                }

                for (int i = 0; i < changeNumbers; ++i)
                {
                    int getIndex = Random.Range(0, indexs.Count);
                    int finalIndex = indexs[getIndex];
                    indexs.RemoveAt(getIndex);
                    solution[finalIndex] = 2;

                }
            }
            else if (rightNumbers == 0)                 // all is right down
            {
                int changeNumbers = Mathf.CeilToInt(solution.Length * 0.3f);
                List<int> indexs = new List<int>();
                for (int i = 0; i < solution.Length; ++i)
                {
                    indexs.Add(i);
                }

                for (int i = 0; i < changeNumbers; ++i)
                {
                    int getIndex = Random.Range(0, indexs.Count);
                    int finalIndex = indexs[getIndex];
                    indexs.RemoveAt(getIndex);
                    solution[finalIndex] = 1;
                }
            }
        }

        private void GenerateMap()
        {
            mapMatrix = new int[this.mapHeight, this.mapWidth];
            
            // Write player path to map matrix
            int mapIndex_y = 0;
            int mapIndex_x = 0;
            for (int i = 0; i < solution.Length; ++i)
            {
                if (solution[i] == 1)        // walk to right
                {
                    ++mapIndex_x;
                }
                else
                {
                    ++mapIndex_y;
                }
                mapMatrix[mapIndex_y, mapIndex_x] = -1;
            }


            // Write Won grid symbol to map matrix
            for (int i = 0; i < mapHeight; ++i)
            {
                mapMatrix[i, this.mapWidth - 1] = 2;
            }

            for (int i = 0; i < mapWidth; ++i)
            {
                mapMatrix[this.mapHeight - 1, i] = 2;
            }

           
            // Write free grid to a list
            List<int> freeGrid = new List<int>();
            for (int y = 0; y < mapHeight; ++y)
            {
                for (int x = 0; x < mapWidth; ++x)
                {
                    if (mapMatrix[y, x] == 0)
                    {
                        int oneDimensionIndex = y * this.mapWidth + x;        // 二维数组映射到一维数组: i = y * rowCount + x 
                        freeGrid.Add(oneDimensionIndex);
                    }
                }
            }

            // Random obstacle grid from free grid and set into mapMatrix, then remove it from free list
            for (int i = 0; i < this.obstacleNumber; ++i)
            {
                int obstacleIndex = Random.Range(0, freeGrid.Count);
                int y = freeGrid[obstacleIndex] / this.mapWidth;
                int x = freeGrid[obstacleIndex] % this.mapWidth;
                mapMatrix[y, x] = 1;
                freeGrid.RemoveAt(obstacleIndex);
            }
        }

        private int CalcGridNumbersByLevelID()
        {
            int index = startLoopOfGridNumber;
            while (index <= levelID)
            {
                ++index;
            }

            int result = startGridNumber + (index - startLoopOfGridNumber);
            return result;
        }


        private int CalcObstacleNumberByGridNumbers()
        {
            int gridNumbers = (this.mapWidth - 1) *(this.mapWidth - 1);
            int minObstacleNumber = Mathf.FloorToInt(gridNumbers / minMultiple);
            int maxObstacleNumber = Mathf.CeilToInt(gridNumbers / maxMultiple);
            int result = (int)Random.Range(minObstacleNumber, maxObstacleNumber);
            return result;
        }

    }
}

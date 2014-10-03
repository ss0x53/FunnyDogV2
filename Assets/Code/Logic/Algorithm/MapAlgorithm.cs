using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AGMAlgorithm
{
    public enum enGrid
    {
        Normal,
        PlayerPath,
        Danger,
        Won,
    }

    public class MapSolution_t
    {
        public int levelID = 0;
        public int maxStep = 0;
        public int minStep = 0; 
        public int obstacleNumber = 0;
        public int mapWidth = 0;
        public int mapHeight = 0;
        //public int[,] mapMatrix;
        //public int[] solution;
        public enGrid[,] mapMatrix;
        
        public enPathDir[] solution;
        

        private int startGridNumber = 4;
        //private int startLoopOfGridNumber = 2;
        private float minMultiple = 3;
        private float maxMultiple = 5;

        private int maxPlayerStep = 10;


        public MapSolution_t(int levelID)
        {
            this.levelID = levelID;
            this.mapWidth = CalcGridNumbersByLevelID();
            this.mapHeight = this.mapWidth;
            this.maxStep = Mathf.CeilToInt(this.mapWidth / 2.0f);
            this.maxStep = this.maxStep > maxPlayerStep ? maxPlayerStep : this.maxStep;
            this.minStep = Mathf.CeilToInt(this.maxStep / 2.0f);
            this.obstacleNumber = CalcObstacleNumberByGridNumbers();
            
            GenerateSolution();
            GenerateMap();
        }

        private void GenerateSolution()
        {
            if (this.minStep <= 1)
            {
                this.minStep = 2;
            }
            int solutionStep = Random.Range(this.minStep, this.maxStep + 1);
            solution = new enPathDir[solutionStep];

            for (int i = 0; i < solutionStep; ++i)
            {
                if (Random.value > 0.5f)
                {
                    solution[i] = enPathDir.Right;        // to right
                }
                else
                {
                    solution[i] = enPathDir.Down;        // to down
                }
            }


            
            // 检查行走路径，若每一步都一样，则随机更改其中的30%为另一不相同的方向
            enPathDir firstStepDir = solution[0];
            bool toChangeDir = true;
            for (int i = 1; i < solution.Length; ++i)
            {
                if (solution[i] != firstStepDir)
                {
                    toChangeDir = false;
                }
            }

            if (toChangeDir)
            {
                int changeNumbers = Mathf.CeilToInt(solution.Length * 0.3f);
                List<int> ppl = new List<int>();
                for (int i = 0; i < solution.Length; ++i)
                {
                    ppl.Add(i);
                }

                for (int i = 0; i < changeNumbers; ++i)
                {
                    int getIndex = Random.Range(0, ppl.Count);
                    ppl.RemoveAt(getIndex);
                    solution[getIndex] = firstStepDir == enPathDir.Right ? enPathDir.Down : enPathDir.Right;
                }
            }


            //for (int i = 0; i < solution.Length; ++i)
            //{
            //    Debug.Log("//// " + solution[i]);
            //}
        }

        private void GenerateMap()
        {
            //mapMatrix = new int[this.mapWidth,this.mapWidth];
            mapMatrix = new enGrid[this.mapWidth, this.mapWidth];
            for (int row = 0; row < this.mapWidth; ++row)
            {
                for (int col = 0; col < this.mapWidth; ++col)
                {
                    mapMatrix[row, col] = enGrid.Normal;
                }
            }


            // set Won Grid info
            for (int i = 0; i < this.mapWidth; ++i)
            {
                mapMatrix[i, this.mapWidth - 1] = enGrid.Won;
                mapMatrix[this.mapWidth - 1, i] = enGrid.Won;
            }


            // Write player path to map

            int indexOfRow = 0;
            int indexOfCol = 0;
            int playerPathIndex = 0;

            while (true)
            {
                if (playerPathIndex == solution.Length)
                {
                    playerPathIndex = 0;
                }
                if (solution[playerPathIndex] == enPathDir.Down)
                {
                    ++indexOfRow;
                }
                else if (solution[playerPathIndex] == enPathDir.Right)
                {
                    ++indexOfCol;
                }

                if (mapMatrix[indexOfRow, indexOfCol] == enGrid.Won)
                {
                    break;
                }
                else
                {
                    mapMatrix[indexOfRow, indexOfCol] = enGrid.PlayerPath;
                }
                ++playerPathIndex;
            }


            // 设置首行随机障碍
            List<int> firstRowIndexList = new List<int>();
            for (int i = 1; i < this.mapWidth; ++i)
            {
                if (mapMatrix[0, i] == enGrid.Normal)
                {
                    firstRowIndexList.Add(i);
                }
            }

            int firstRowObstacleIndex = Random.Range(0, firstRowIndexList.Count);
            mapMatrix[0, firstRowIndexList[firstRowObstacleIndex]] = enGrid.Danger;
            --this.obstacleNumber;

            // 设置首列随机障碍
            List<int> firstColIndexList = new List<int>();
            for (int i = 1; i < this.mapWidth; ++i)
            {
                if (mapMatrix[i, 0] == enGrid.Normal)
                {
                    firstColIndexList.Add(i);
                }
            }

            int firstColObstacleIndex = Random.Range(0, firstColIndexList.Count);
            mapMatrix[firstColIndexList[firstColObstacleIndex], 0] = enGrid.Danger;
            --this.obstacleNumber;

            // collection free grid
            //List<enGrid> freeGrid = new List<enGrid>();
            List<int> freeGridIndexList = new List<int>();
            for (int row = 0; row < this.mapWidth; ++row)
            {
                for (int col = 0; col < this.mapWidth; ++col)
                {
                    if (mapMatrix[row, col] == enGrid.Normal)
                    {
                        //freeGrid.Add(mapMatrix[row, col]);
                        freeGridIndexList.Add(row * this.mapWidth + col);
                    }
                }
            }

            freeGridIndexList.RemoveAt(0);


            // set obstacle to free grid

            for (int i = 0; i < this.obstacleNumber; ++i)
            {
                int choiceIndex = Random.Range(0, freeGridIndexList.Count);
                int x = freeGridIndexList[choiceIndex] / this.mapWidth;
                int y = freeGridIndexList[choiceIndex] % this.mapWidth;
                mapMatrix[x, y] = enGrid.Danger;
                freeGridIndexList.RemoveAt(choiceIndex);
                //freeGrid[choiceIndex] = enGrid.Danger;
                //freeGrid.RemoveAt(choiceIndex);
            }

        }

        private int CalcGridNumbersByLevelID()
        {
            int increase = levelID / 2;
            return startGridNumber + increase;
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

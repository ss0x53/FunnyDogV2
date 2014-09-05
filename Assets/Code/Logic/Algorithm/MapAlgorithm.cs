using UnityEngine;
using System.Collections;

namespace AGMAlgorithm
{
    public class MapSolution_t
    {
        public int maxStep = 0;
        public int minStep = 0;
        public int obstacleNumber = 0;
        public int mapWidth = 0;
        public int mapHeight = 0;
        public int[,] mapMatrix;        // 0 is available grid, 1 is obstacle
        public int[] solution;          // 1 is to right, 2 is to down

        public MapSolution_t(int _minStep, int _maxStep, int _mapWidth, int _mapHeight, int _obstacleNumber)
        {
            this.minStep = _minStep;
            this.maxStep = _maxStep;
            this.mapWidth = _mapWidth;
            this.mapHeight = _mapHeight;
            this.obstacleNumber = _obstacleNumber;
            GenerateSolution();
            GenerateMap();
        }

        private void GenerateSolution()
        {

        }

        private void GenerateMap()
        {

        }
    }
}

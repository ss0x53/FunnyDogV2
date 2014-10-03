using UnityEngine;
using System.Collections;
using AGMAlgorithm;
using System.Collections.Generic;

public class PathGridIniter : MonoBehaviour {

    private string resPath_Grid = "GamePlayElements/";
    List<GameObject> grids = new List<GameObject>();

    public Vector3 InitPath(MapSolution_t _data)
    {
        DestroyAllGrids();

        int screen_width = Screen.width;
        int screen_height = Screen.height;
        int grid_interval = 5;
        float grid_size = (720 - (_data.mapWidth - 1) * grid_interval) / _data.mapWidth;
        float start_pos_x = (-720 / 2) + grid_size / 2;
        float start_pos_y = 210 + 720 / 2 - grid_size / 2;
        //transform.localPosition = new Vector3(0, -(25 + grid_size / 2 + 20), 0);    // 25 is LevelLabel pos_y, 20 is LevelLabel's height / 2 + 5

        Vector3 gridPos = new Vector3(start_pos_x, start_pos_y, 0);

        for (int row = 0; row < _data.mapWidth; ++row)
        {
            for (int col = 0; col < _data.mapWidth; ++col)
            {
                GameObject grid;
                if (_data.mapMatrix[row, col] == enGrid.Danger)
                {
                    grid = GlobalManager.Instance.GetAssetsManager.GetGameObject(resPath_Grid, "GridDanger");
                }
                else if (_data.mapMatrix[row, col] == enGrid.Normal || _data.mapMatrix[row, col] == enGrid.PlayerPath)
                {
                    grid = GlobalManager.Instance.GetAssetsManager.GetGameObject(resPath_Grid, "GridNormal");
                }
                else
                {
                    grid = GlobalManager.Instance.GetAssetsManager.GetGameObject(resPath_Grid, "GridWon");
                    if (row == _data.mapWidth - 1)
                    {
                        grid.transform.eulerAngles = new Vector3(0, 0, 90);
                    }
                }

                grid.transform.parent = transform;
                grid.GetComponent<UISprite>().SetDimensions((int)grid_size, (int)grid_size);
                grid.transform.localScale = new Vector3(1, 1, 1);
                grid.transform.localPosition = gridPos;
                gridPos += new Vector3(grid_size + grid_interval, 0, 0);
            }
            gridPos -= new Vector3(0, grid_size + grid_interval, 0);
            gridPos.x = start_pos_x;
        }


            return new Vector3(start_pos_x, start_pos_y, grid_size + grid_interval);
    }


    void DestroyAllGrids()
    {
        foreach (GameObject grid in grids)
        {
            Destroy(grid);
        }
        grids.Clear();
    }

}

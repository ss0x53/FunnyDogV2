using UnityEngine;
using System.Collections;
using AGMAlgorithm;
using System.Collections.Generic;

public class PathGridIniter : MonoBehaviour {

    List<GameObject> grids = new List<GameObject>();

    public Vector3 InitPath(MapSolution_t _data)
    {
        DestroyAllGrids();

        int screen_width = Screen.width;
        int screen_height = Screen.height;
        int grid_interval = 5;
        float grid_size = (screen_width - (_data.mapWidth + 1) * grid_interval) / _data.mapWidth;
        float start_pos_x = (-screen_width / 2) + grid_size / 2 + grid_interval;

        transform.localPosition = new Vector3(0, -(25 + grid_size / 2 + 20), 0);    // 25 is LevelLabel pos_y, 20 is LevelLabel's height / 2 + 5

        Vector3 gridPos = new Vector3(start_pos_x, 0, 0);

        for (int y = 0; y < _data.mapHeight; ++y)
        {
            for (int x = 0; x < _data.mapWidth; ++x)
            {
                GameObject grid;
                if (_data.mapMatrix[y, x] == 0)
                {
                    grid = GlobalManager.Instance.GetAssetsManager.GetGameObject("GridNormal");
                }
                else if (_data.mapMatrix[y, x] == 1)
                {
                    grid = GlobalManager.Instance.GetAssetsManager.GetGameObject("GridDanger");
                }
                else
                {
                    grid = GlobalManager.Instance.GetAssetsManager.GetGameObject("GridWon");
                }

                grid.transform.parent = transform;
                grid.transform.localScale = new Vector3(grid_size, grid_size, grid_size);
                grid.transform.localPosition = gridPos;
                gridPos += new Vector3(grid_size + grid_interval, 0, 0);
            }
            gridPos += new Vector3(0, grid_size + grid_interval, 0);
            gridPos.x = start_pos_x;
        }

        return new Vector3(start_pos_x, transform.localPosition.y, grid_size + grid_interval);
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

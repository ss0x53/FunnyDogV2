using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowGridIniter : MonoBehaviour {

    private string resPath_Arrow = "GamePlayElements/";

    public List<GameObject> grids = new List<GameObject>();
    private List<GameObject> arrows = new List<GameObject>();
    private int nextAvailableGridId = 0;
    public void InitArrowGrid(int number)
    {
        DestroyTmpObjs();

        for (int i = 0; i < grids.Count; ++i)
        {
            if (i >= number)
            {
                SetGridDisable(grids[i]);
            }
            //else
            //{
            //    ++nextAvailableGridId;
            //}
        }
    }




    public void SetGridEnable(GameObject grid)
    {
        grid.GetComponent<UISprite>().color = Color.white;

    }


    public void SetGridDisable(GameObject grid)
    {
        grid.GetComponent<UISprite>().color = Color.gray;
    }



    public void AddArrow(enPathDir dir)
    {
        GameObject arrow;
        if (dir == enPathDir.Right)
        {
            arrow = GlobalManager.Instance.GetAssetsManager.GetGameObject(resPath_Arrow, "ArrowRight");
        }
        else
        {
            arrow = GlobalManager.Instance.GetAssetsManager.GetGameObject(resPath_Arrow, "ArrowDown");
        }

        Transform arrowParent = grids[nextAvailableGridId++].transform;
        arrow.transform.parent = arrowParent;
        arrow.transform.localScale = new Vector3(1, 1, 1);
        arrow.GetComponent<UISprite>().SetDimensions(93,93);
        arrow.transform.localPosition = Vector3.zero;
        arrows.Add(arrow);
    }


    public void RemoveArrow()
    {
        int id = arrows.Count - 1;
        GameObject arrow = arrows[id];
        arrows.RemoveAt(id);
        Destroy(arrow);
        --nextAvailableGridId;
    }



    void DestroyTmpObjs()
    {
        foreach (GameObject obj in arrows)
        {
            Destroy(obj);
        }

        arrows.Clear();
    }
	
}

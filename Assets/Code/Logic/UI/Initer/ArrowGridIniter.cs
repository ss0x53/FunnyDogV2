using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowGridIniter : MonoBehaviour {

    private List<GameObject> grids = new List<GameObject>();
    private List<GameObject> arrows = new List<GameObject>();
    public void InitArrowGrid(int number)
    {
        DestroyTmpObjs();
        for (int i = 0; i < number; ++i)
        {
            GameObject go = GlobalManager.Instance.GetAssetsManager.GetGameObject("Grid");
            grids.Add(go);
        }
        ReposAllGrids();
    }


    void ReposAllGrids()
    {

    }


    public void AddArrow()
    {
        GameObject arrow = GlobalManager.Instance.GetAssetsManager.GetGameObject("Arrow");
        int arrowPosID = grids.Count;
        Transform arrowParent = grids[arrowPosID].transform;
        arrow.transform.parent = arrowParent;
        arrow.transform.localPosition = Vector3.zero;
        arrows.Add(arrow);
    }


    public void RemoveArrow()
    {
        int id = arrows.Count - 1;
        GameObject arrow = arrows[id];
        arrows.RemoveAt(id);
        Destroy(arrow);
    }



    void DestroyTmpObjs()
    {
        foreach (GameObject obj in arrows)
        {
            Destroy(obj);
        }

        foreach (GameObject obj in grids)
        {
            Destroy(obj);
        }

        grids.Clear();
        arrows.Clear();
    }
	
}

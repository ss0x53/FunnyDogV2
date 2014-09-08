using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestPlayer : MonoBehaviour {
    List<enPathDir> myPath = new List<enPathDir>();
    int pathIndex = 0;
    Vector3 targetPos = Vector3.zero;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 10; ++i)
        {
            if (Random.value > 0.5f)
            {
                myPath.Add(enPathDir.Right);
            }
            else
            {
                myPath.Add(enPathDir.Down);
            }
        }
        StartCoroutine(PlayerMove());
        targetPos = transform.position;
	}
	
	    

    IEnumerator PlayerMove()
    {
        foreach (enPathDir dir in myPath)
        {
            Vector3 targetPos = Vector3.zero;
            if (dir == enPathDir.Right)
            {
                targetPos = transform.position + new Vector3(1, 0, 0);
            }
            else
            {
                targetPos = transform.position + new Vector3(0, -1, 0);
                
            }

                while (transform.position != targetPos)
                {
                    transform.position = Vector3.Lerp(transform.position, targetPos, 0.3f);
                    yield return new WaitForSeconds(Time.deltaTime);
                }
            Debug.Log(dir);
        }
        yield return 0;
    }
}

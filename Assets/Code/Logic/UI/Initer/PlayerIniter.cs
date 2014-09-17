using UnityEngine;
using System.Collections;

public class PlayerIniter : MonoBehaviour {

    private string resPath_Player = "GamePlayElements/";

    private GameObject player = null;


    public void InitPlayer(Vector3 pos)
    {
        transform.localPosition = new Vector3(0, pos.y, 0);
        if (player == null)
        {
            player = GlobalManager.Instance.GetAssetsManager.GetGameObject(resPath_Player,"Player");
        }

        player.GetComponent<Player>().SetPlayerOriginState(new Vector3(pos.x,0,pos.z));
    }
}

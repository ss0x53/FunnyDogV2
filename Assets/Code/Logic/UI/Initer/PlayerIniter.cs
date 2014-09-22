using UnityEngine;
using System.Collections;

public class PlayerIniter : MonoBehaviour {

    private string resPath_Player = "GamePlayElements/";

    private GameObject player = null;


    public void InitPlayer(Vector3 pos)
    {
        if (player == null)
        {
            player = GlobalManager.Instance.GetAssetsManager.GetGameObject(resPath_Player,"Player");
            player.transform.parent = transform;
            player.transform.localPosition = new Vector3(pos.x, pos.y);
            player.transform.localScale = new Vector3(1,1,1);
            player.GetComponent<UISprite>().SetDimensions((int)pos.z, (int)pos.z);
        }

        //player.GetComponent<Player>().SetPlayerOriginState(new Vector3(pos.x,0,pos.z));
    }
}

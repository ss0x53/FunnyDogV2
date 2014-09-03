using UnityEngine;
using System.Collections;

public class PlayerIniter : MonoBehaviour {

    private GameObject player = null;


    public void InitPlayer()
    {
        if (player == null)
        {
            player = GlobalManager.Instance.GetAssetsManager.GetGameObject("Player");
        }

        player.GetComponent<Player>().SetPlayerOriginState();
    }
}

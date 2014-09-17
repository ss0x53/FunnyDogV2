using UnityEngine;
using System.Collections;

public class ICompanyLogoController : MonoBehaviour {
    public GameObject companyLogo = null;
	void Start () {
        Invoke("FadeCompanyLogo", 0.5f);
	}


    public void FadeCompanyLogo()
    {
        companyLogo.GetComponent<EffectFader>().Fade(enFadeType.Fade_NGUITexture, new Color(1, 1, 1, 1), 0.1f, CompanyLogoDisplayOver);
    }


    public void CompanyLogoDisplayOver()
    {
        companyLogo.GetComponent<EffectFader>().Fade(enFadeType.Fade_NGUITexture, new Color(1, 1, 1, 0), 0.08f, CompanyLogoHideOver); 
    }

    public void CompanyLogoHideOver()
    {
        GlobalManager.Instance.GetGameManager.SwitchGameState(enGameState.GameState_CompanyLogo, enGameState.GameState_GameMainMenu);
    }

}

// Author : Frederic
// Date   : 2014-09-01
// Doc    : 游戏全局管理器，执行游戏的初始化工作

using UnityEngine;
using System.Collections;
using Umeng;

public class GlobalManager : MonoBehaviour {

    private static GlobalManager m_Instance;
    public static GlobalManager Instance
    {
        get { return m_Instance; }
    }

    private GameController c_GameController;
    private LevelManager m_LevelManager;
    private AssetsManager m_AssetsManager;
    private DataManager m_DataManager;
    private UIManager m_UIManager;
    private GameManager m_GameManager;
    private ADController m_AdController;
    private AudioController m_AudioController;

    // Disable AD
    static public int adKillCode = 0;
    private float exitTimeRecorder = 0;




    void Awake()
    {
        GA.StartWithAppKeyAndChannelId("5440b4d0fd98c5593a010814", "91");        // UMeng
        DontDestroyOnLoad(gameObject);
        m_Instance = this;
        Init();
        m_AdController = GameObject.Find("ADController").GetComponent<ADController>();
        // Game Start Trigger
        m_GameManager.SwitchGameState(m_GameManager.GetCurrentGameState(), m_GameManager.GetTargetGameState());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GlobalManager.Instance.GetGameManager.GetCurrentGameState() == enGameState.GameState_GamePlay)
            {
                GlobalManager.Instance.GetGameManager.SwitchGameState(enGameState.GameState_GamePlay, enGameState.GameState_GameMainMenu);
            }
            if (GlobalManager.Instance.GetGameManager.GetCurrentGameState() == enGameState.GameState_GameMainMenu)
            {
                if (Time.realtimeSinceStartup - exitTimeRecorder < 0.3f)
                {
                    //Application.Quit();
                    m_AdController.AndroidExit();
                }
                else
                {
                    exitTimeRecorder = Time.realtimeSinceStartup;
                }
            }
        }
    }


    private void Init()
    {
        c_GameController = new GameController();
        m_LevelManager = new LevelManager();
        m_AssetsManager = new AssetsManager();
        m_DataManager = new DataManager();
        m_UIManager = new UIManager();
        m_GameManager = new GameManager();

        m_DataManager.Init();
        m_UIManager.Init();
        m_GameManager.Init();
        c_GameController.InitGame();
    }

    public GameController GetGameController
    {
        get { return c_GameController; }
    }

    public LevelManager GetLevelManager
    {
        get { return m_LevelManager; }
    }

    public AssetsManager GetAssetsManager
    {
        get { return m_AssetsManager; }
    }

    public DataManager GetDataManager
    {
        get { return m_DataManager; }
    }

    public UIManager GetUIManager
    {
        get { return m_UIManager; }
    }

    public GameManager GetGameManager
    {
        get { return m_GameManager; }
    }

    public ADController GetAdController
    {
        get { return m_AdController; }
    }

    public AudioController GetAudioController
    {
        get { return m_AudioController; }
    }

	
}

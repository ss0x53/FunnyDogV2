// Author : Frederic
// Date   : 2014-09-01
// Doc    : 游戏全局管理器，执行游戏的初始化工作

using UnityEngine;
using System.Collections;

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

    void Awake()
    {
        m_Instance = this;
        Init();
        DontDestroyOnLoad(gameObject);
    }

    private void Init()
    {
        c_GameController = new GameController();
        m_LevelManager = new LevelManager();
        m_AssetsManager = new AssetsManager();
        m_DataManager = new DataManager();
        m_UIManager = new UIManager();

        m_DataManager.Init();
        m_UIManager.Init();
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

	
}

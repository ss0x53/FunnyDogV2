// Author : Frederic
// Date   : 2014-09-01
// Doc    : UI的全局管理，加载，销毁等

using UnityEngine;
using System.Collections;

public enum enInterfaceName
{
    InterfaceName_None = -1,
    InterfaceName_CompanyLogo,
    InterfaceName_GameLogo,
    InterfaceName_GameAD,
    InterfaceName_GameMainMenu,
    InterfaceName_GamePlay,
    InterfaceName_GameAbout,
    InterfaceName_GameIfExit,
    InterfaceName_Max,
}

public class UIManager {

    private string[] m_InterfaceResourcePathArray;
    private GameObject[] m_InterfaceGameObjectArray;
    private Transform m_UICameraTrans;

    public void Init()
    {
        m_InterfaceResourcePathArray = new string[(int)enInterfaceName.InterfaceName_Max];

        m_InterfaceResourcePathArray[(int)enInterfaceName.InterfaceName_CompanyLogo]    = "Interface/Interface_CompanyLogo";
        m_InterfaceResourcePathArray[(int)enInterfaceName.InterfaceName_GameLogo]       = "Interface/Interface_GameLogo";
        m_InterfaceResourcePathArray[(int)enInterfaceName.InterfaceName_GameLogo]       = "Interface/Interface_GameAD";
        m_InterfaceResourcePathArray[(int)enInterfaceName.InterfaceName_GameMainMenu]   = "Interface/Interface_MainMenu";
        m_InterfaceResourcePathArray[(int)enInterfaceName.InterfaceName_GamePlay]       = "Interface/Interface_GamePlay";
        m_InterfaceResourcePathArray[(int)enInterfaceName.InterfaceName_GameAbout]      = "Interface/Interface_GameAbout";
        m_InterfaceResourcePathArray[(int)enInterfaceName.InterfaceName_GameIfExit]     = "Interface/Interface_IfExit";

        m_InterfaceGameObjectArray = new GameObject[(int)enInterfaceName.InterfaceName_Max];
        m_UICameraTrans = GameObject.Find("UI Root/Camera").transform;

    }


    public void AddInterface(enInterfaceName interfaceName)
    {
        GameObject obj = GameObject.Instantiate(Resources.Load(m_InterfaceResourcePathArray[(int)interfaceName])) as GameObject;
        if (obj)
        {
            obj.transform.parent = m_UICameraTrans;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = new Vector3(1, 1, 1);
            obj.SetActive(true);
            m_InterfaceGameObjectArray[(int)interfaceName] = obj;
        }
    }


    public void RemoveInterface(enInterfaceName interfaceName)
    {
        if (m_InterfaceGameObjectArray[(int)interfaceName])
        {
            GameObject.Destroy(m_InterfaceGameObjectArray[(int)interfaceName]);
        }
    }


    public void EnableInterface(enInterfaceName interfaceName)
    {
        if (m_InterfaceGameObjectArray[(int)interfaceName])
        {
            m_InterfaceGameObjectArray[(int)interfaceName].SetActive(true);
        }
        else
        {
            AddInterface(interfaceName);
        }
    }


    public void DisableInterface(enInterfaceName interfaceName)
    {
        if (m_InterfaceGameObjectArray[(int)interfaceName])
        {
            m_InterfaceGameObjectArray[(int)interfaceName].SetActive(false);
        }
    }

}



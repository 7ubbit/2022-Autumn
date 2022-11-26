using System;
using UnityEngine;
/// <summary>
/// 坦克管理类(已给出，无需修改)
/// </summary>
[Serializable] //序列化 具体可查看Unity API中关于序列化
public class TankManager
{
    // 该类用于管理坦克上的各种设置
    // 它与GameManager类一起控制坦克的行为
    // 以及玩家是否能够控制他们的坦克
    // 游戏的不同阶段
    public Color m_PlayerColor;                                 //坦克要着色的颜色。
    public Transform m_SpawnPoint;                              //坦克出生坐标。
    [HideInInspector] public int m_PlayerNumber;                //区分两位玩家
    [HideInInspector] public string m_ColoredPlayerText;        //表示Player的字符串，其颜色为与其坦克相匹配。
    [HideInInspector] public GameObject m_Instance;             //引用创建时的坦克实例。
    [HideInInspector] public int m_Wins;                        //到目前为止，这位玩家赢了多少场。
    private TankMovement m_Movement;                            //引用坦克的运动脚本，用于禁用和启用控制。
    private TankShooting m_Shooting;                            //引用坦克的射击脚本，用于禁用和启用控制。
    private GameObject m_CanvasGameObject;                      //用于在每一轮的开始和结束阶段禁用World Space UI。


    public void Setup()
    {
        m_Movement = m_Instance.GetComponent<TankMovement>();
        m_Shooting = m_Instance.GetComponent<TankShooting>();
        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

        m_Movement.m_PlayerNumber = m_PlayerNumber;
        m_Shooting.m_PlayerNumber = m_PlayerNumber;

        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";

        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = m_PlayerColor;
        }
    }


    public void DisableControl()
    {
        m_Movement.enabled = false;
        m_Shooting.enabled = false;

        m_CanvasGameObject.SetActive(false);
    }


    public void EnableControl()
    {
        m_Movement.enabled = true;
        m_Shooting.enabled = true;

        m_CanvasGameObject.SetActive(true);
    }


    public void Reset()
    {
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}

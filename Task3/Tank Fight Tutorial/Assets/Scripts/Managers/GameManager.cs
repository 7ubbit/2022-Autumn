using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// 游戏管理类 (已给出部分代码,需补充)
/// </summary>
public class GameManager : MonoBehaviour
{

    public int m_NumRoundsToWin = 5;                //单个玩家必须赢得的回合数才能赢得游戏。
    public float m_StartDelay = 3f;                 //从循环启动阶段开始到循环阶段结束之间的延迟。
    public float m_EndDelay = 3f;
    public CameraControl m_CameraControl;           //引用CameraControl脚本，在不同阶段进行控制。
    public Text m_MessageText;                      //引用覆盖文本以显示获奖文本等。
    public GameObject m_TankPrefab;                 //引用玩家将控制的预制件。
    public TankManager[] m_Tanks;                   //一组TankManager，负责使坦克的不同方面能够使用和使其失效。
    private int m_RoundNumber;                      //当前正在进行哪一轮比赛。
    private WaitForSeconds m_StartWait;             //在回合开始时的延迟。 
    private WaitForSeconds m_EndWait;               //在回合或比赛结束时会有延迟。
    /*  
    private TankManager m_RoundWinner;              //声明回合胜利者
    private TankManager m_GameWinner;               //声明游戏胜利者
    */

    private void Start()
    {
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        SpawnAllTanks();
        SetCameraTargets();

        StartCoroutine(GameLoop());
    }


    private void SpawnAllTanks()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].m_Instance =
                Instantiate(m_TankPrefab, m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
            m_Tanks[i].m_PlayerNumber = i + 1;
            m_Tanks[i].Setup();
        }
    }


    private void SetCameraTargets()
    {
        Transform[] targets = new Transform[m_Tanks.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = m_Tanks[i].m_Instance.transform;
        }

        m_CameraControl.m_Targets = targets;
    }


    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());

        /*        if (m_GameWinner != null)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    StartCoroutine(GameLoop());
                }
        */
    }


    private IEnumerator RoundStarting()
    {
        //自己尝试写入回合准备阶段的代码
        yield return m_StartWait;
    }


    private IEnumerator RoundPlaying()
    {
        //自己尝试写入回合开始阶段的代码
        yield return null;
    }


    private IEnumerator RoundEnding()
    {
        //自己尝试写入回合结束阶段的代码
        yield return m_EndWait;
    }


    private bool OneTankLeft()
    {
        int numTanksLeft = 0;

        for (int i = 0; i < m_Tanks.Length; i++)
        {
            if (m_Tanks[i].m_Instance.activeSelf)
                numTanksLeft++;
        }

        return numTanksLeft <= 1;
    }

    /*
        private TankManager GetRoundWinner()
        {
            for (int i = 0; i < m_Tanks.Length; i++)
            {
                if (m_Tanks[i].m_Instance.activeSelf)
                    return m_Tanks[i];
            }

            return null;
        }


        private TankManager GetGameWinner()
        {
            for (int i = 0; i < m_Tanks.Length; i++)
            {
                if (m_Tanks[i].m_Wins == m_NumRoundsToWin)
                    return m_Tanks[i];
            }

            return null;
        }


        private string EndMessage()
        {
            string message = "DRAW!";

            if (m_RoundWinner != null)
                message = m_RoundWinner.m_ColoredPlayerText + " WINS THE ROUND!";

            message += "\n\n\n\n";

            for (int i = 0; i < m_Tanks.Length; i++)
            {
                message += m_Tanks[i].m_ColoredPlayerText + ": " + m_Tanks[i].m_Wins + " WINS\n";
            }

            if (m_GameWinner != null)
                message = m_GameWinner.m_ColoredPlayerText + " WINS THE GAME!";

            return message;
        }
    */

    private void ResetAllTanks()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].Reset();
        }
    }


    private void EnableTankControl()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].EnableControl();
        }
    }


    private void DisableTankControl()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].DisableControl();
        }
    }
}